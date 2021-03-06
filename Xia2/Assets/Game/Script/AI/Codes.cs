using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FSMTestingProject
{
    /// <summary>
    /// 状态机中，当前状态发生改变的事件委托声明
    /// </summary>
    public delegate void CurStateChangedEventHandler(FSM sender);

    /// <summary>
    /// 状态机中，当有参数发生变化时的事件委托声明
    /// </summary>
    public delegate void ParamsChangedEventHandler(FSM sender, ParamsChangedEvent args);

    /// <summary>
    /// 过度参数为函数委托的声明
    /// </summary>
    public delegate bool FuncParamHandler(params object[] objs);

    /// <summary>
    /// 状态机中，当有参数发生变化时的参数类声明
    /// </summary>
    public class ParamsChangedEvent : EventArgs
    {
        private Param lastValue;
        public Param LastValue
        {
            get { return lastValue; }
        }

        private Param curValue;
        public Param CurValue
        {
            get { return curValue; }
        }

        public ParamsChangedEvent(Param lastValue, Param curValue)
        {
            this.lastValue = lastValue;
            this.curValue = curValue;
        }
    }

    /// <summary>
    /// 状态参数检验异常类
    /// </summary>
    public class FSMParamInvalidatedException : Exception
    {
        public FSMParamInvalidatedException(string msg)
            : base(msg)
        {

        }
    }

    /// <summary>
    /// 有限状态机
    /// (
    ///     设计思路，参考：Unity 4.3.2f 版本的Mecanim动画系统中的状态机，
    ///     根据使用上的功能，来猜想实现思路，当然可能我的实现方式不是最好，
    ///     如果大家还有比较好的一些见解，那大家一起交流交流吧。
    ///     该博文就不多说其它的，我的文采也不好，直接上代码吧。
    ///     1.1：修正：1.0版本的一个Pipeline的多个条件之间为：“与”关系
    ///     1.3：完善：Transition, ChangedStatePipeline，PipelineCondition与FSM之关系
    ///         让每个以上三类对象，都分别在各各FSM，或是他们类之间最大化可共用；
    ///     1.4：优化：FSM中的AnyState与CurState的进入，与离开的触发位置（放在Update中处理，即下一帧中处理）
    ///         添加：FSM中的Blackboard黑板数据设计（有点像BT树中的黑板数据）
    /// )
    /// @author :   Jave.Lin(afeng)
    /// @time   :   2014-03-11
    /// @version:   1.1
    /// </summary>
    public class FSM
    {
        /// <summary>
        /// throw an FSMParamInvalidatedException
        /// </summary>
        public static void CheckParamValidated(FSM fsm, string name, object args, ConditionType type)
        {
            if ((type != ConditionType.Func || type == ConditionType.None) && args == null)
                throw new FSMParamInvalidatedException(string.Format("ChangStatePipeline add condition args can not be null"));
            var srcParam = fsm.GetParam(name);
            if (srcParam == null)
                throw new FSMParamInvalidatedException(string.Format("fsm not contains param : {0}", name));
            if (!srcParam.CheckValue(args))
                throw new FSMParamInvalidatedException(string.Format("ChangStatePipeline add condition args ValidatedSelf invalidated : {0}", args));
        }

        public static void TransitionTo(FSM fsm, string srcStateName, string targetStateName, Condition[] conditions)
        {
            TransitionTo(fsm, srcStateName, targetStateName, new List<Condition>(conditions), true);
        }

        public static void TransitionTo(FSM fsm, string srcStateName, string targetStateName, List<Condition> conditions)
        {
            TransitionTo(fsm, srcStateName, targetStateName, conditions, true);
        }

        public static void TransitionTo(FSM fsm, string srcStateName, string targetStateName, List<Condition> conditions, bool addInSameStateNameTransition)
        {
            Transition transition = null;
            Pipeline pipeline = null;
            GetTransitionAndPipeline(fsm, srcStateName, targetStateName, addInSameStateNameTransition, out transition, out pipeline);
            pipeline.AddConditions(conditions);
        }

        public static void GetTransitionAndPipeline(FSM fsm, string srcStateName, string targetName, bool addInSameStateNameTransition, out Transition out1, out Pipeline out2)
        {
            out1 = null;
            out2 = null;

            var srcState = fsm.GetState(srcStateName);
            if (srcState == null)
                return;
            if (addInSameStateNameTransition)
            {
                var ts = srcState.GetTransition(srcStateName, targetName);
                if (ts.Count > 0)
                    out1 = ts[0];
                if (out1 != null)
                {
                    var ps = out1.GetPipeline(srcStateName, targetName);
                    if (ps.Count > 0)
                        out2 = ps[0];
                }
            }
            if (out1 == null)
            {
                out1 = new Transition(srcStateName, targetName);
                srcState.AddTransition(out1);
            }
            if (out2 == null)
            {
                out2 = new Pipeline(srcStateName, targetName);
                out1.AddPipeline(out2);
            }
        }

        public event CurStateChangedEventHandler CurStateChangedEvent;
        public event ParamsChangedEventHandler ParamsChangedEvent;

        private readonly Dictionary<string, Param> fsmParams = new Dictionary<string, Param>();
        private readonly Blackboard blackboard = new Blackboard();

        public string name;

        private State lastState;

        public Blackboard Blackboard
        {
            get { return blackboard; }
        }

        public State LastState
        {
            get { return lastState; }
        }

        private State curState;

        public State CurState
        {
            get { return curState; }
            set { curState = value; }
        }

        private State lastAnyState;
        public State LastAnyState
        {
            get { return lastAnyState; }
        }

        private State anyState;
        public State AnyState
        {
            get { return anyState; }
            set { anyState = value; }
        }

        private Dictionary<string, State> states = new Dictionary<string, State>();

        public FSM()
            : this("FSM")
        {

        }

        public FSM(string name)
        {
            this.name = name;
        }

        public Param AddParam(string name, ParamType type)
        {
            Param result = fsmParams.ContainsKey(name) ? fsmParams[name] : null;

            if (result != null)
            {
                if (result.Type != type)
                    throw new Exception(string.Format("FSM AddParam name : {0}, is already def, but still add param same name, but type different, src type : {1}, new type : {2}", result.Type, type));
            }

            if (result == null)
            {
                result = new ParamValue(name) { Type = type };
                switch (type)
                {
                    case ParamType.Int:
                        result.Value = 0;
                        break;
                    case ParamType.Float:
                        result.Value = 0f;
                        break;
                    case ParamType.Double:
                        result.Value = 0D;
                        break;
                    case ParamType.Boolean:
                        result.Value = false;
                        break;
                    case ParamType.Func:
                        result.Value = null;
                        break;
					case ParamType.Str:
						result.Value = "";
						break;
                }
                AddParam(result);
            }

            return result;
        }

        public void AddParam(Param param)
        {
            if (param == null || fsmParams.ContainsKey(param.Name))
                return;
            if (!param.CheckValue())
                throw new Exception(string.Format("fsm add param ValidatedSelf invalidated : {0}", param));
            fsmParams.Add(param.Name, param);
        }

        public void RemoveParam(Param param)
        {
            if (param == null || !fsmParams.ContainsKey(param.Name))
                return;
            fsmParams.Remove(param.Name);
        }

        public T GetParam<T>(string name) where T : Param
        {
            return GetParam(name) as T;
        }

        public T GetParamValue<T>(string name) where T : struct
        {
            return GetParam(name).GetValue<T>();
        }

        public T GetParamClassValue<T>(string name) where T : class
        {
            return GetParam(name).GetClassValue<T>();
        }

        public Param GetParam(string name)
        {
            if (!fsmParams.ContainsKey(name))
                return null;
            return fsmParams[name];
        }

        public void SetParamValue(string name, object value)
        {
            SetParamValue(name, value, true);
        }

        public void SetParamValue(string name, object value, bool autoAsValue)
        {
            var srcParam = GetParam(name);
            if (srcParam == null)
                throw new Exception(string.Format("FSM.SetParamValue param : name : {0} is not contains", name));

			if(srcParam.Type == ParamType.UnityGameObject)
			{
				value = (GameObject)value;
			}
            else if (autoAsValue && value.GetType() != srcParam.Value.GetType())
            {
                try
                {
                    switch (srcParam.Type)
                    {
                        case ParamType.Int:
                            value = Convert.ToInt32(value);
                            break;
                        case ParamType.Float:
                            value = Convert.ToSingle(value);
                            break;
                        case ParamType.Double:
                            value = Convert.ToDouble(value);
                            break;
                        case ParamType.Func:
                            value = (Delegate)(value);
                            break;
						case ParamType.Str:
							value = Convert.ToString(value);
							break;
                        default:
                            throw new Exception(string.Format("FSM.SetParamValue new param type unhandled, type : {0}", srcParam.Type));
                    }
                }
                catch (Exception er)
                {
                    throw new Exception(string.Format("FSM.SetParamValue param : name : {0}, value is invalidated : {1}\nException:{2}", name, value, er.ToString()));
                }
            }

            if (!srcParam.CheckValue(value))
                throw new Exception(string.Format("FSM.SetParamValue param : name : {0}, value is invalidated : {1}", name, value));

            var lastValue = srcParam.Clone();
            srcParam.Value = value;
            OnParamsChangedEvent(new ParamsChangedEvent(lastValue, srcParam));
            if (curState != null)
                curState.DirtyState();
        }

        public void AddState(State state)
        {
            if (states.ContainsKey(state.Name)) return;
            states.Add(state.Name, state);
        }

        public void RemoveState(State state)
        {
            if (state == null || !states.ContainsKey(state.Name)) return;
            states.Remove(state.Name);
        }

        public State GetState(string name)
        {
            if (!states.ContainsKey(name))
                return null;
            return states[name];
        }
		public State getNextState()
		{
			State cur = curState;
			string name = cur.Name;
			int idx = -1;
			for(int i = 0; i < states.Count; i++)
			{
				if(string.Compare(states.ElementAt(i).Value.Name, name) == 0)
				{
					idx = i;
				}
			}
			idx++;
			if(idx >= states.Count)
			{
				return null;
			}
			return states.ElementAt (idx).Value;
		}

        public void Update()
		{	
			if (anyState != lastAnyState)
            {
                if (lastAnyState != null)
                {
                    lastAnyState.LeaveState(this);
                }
                lastAnyState = anyState;
                if (anyState != null)
                {
                    anyState.EnterState(this);
                }
            }
            if (anyState != null)
            {
                anyState.Update(this);
                anyState.Excute(this);
            }

            if (curState != lastState)
            {

                if (lastState != null)
                {
                    lastState.Leave(this);
                }
                lastState = curState;
                if (curState != null)
                {
                    curState.Enter(this);
                }
            }
            if (curState != null && curState!= anyState && curState.IsEnter == true)
            {
                curState.Update(this);
				curState.Excute(this);
            }

        }

        public void SetCurState(string stateName)
        {
            curState = GetState(stateName);
        }

        private void OnCurStateChangedEvent()
        {
            if (CurStateChangedEvent != null)
            {
                CurStateChangedEvent(this);
            }
        }

        private void OnParamsChangedEvent(ParamsChangedEvent args)
        {
            if (ParamsChangedEvent != null)
            {
                ParamsChangedEvent(this, args);
            }
        }

        public override string ToString()
        {
            return string.Format("fsm : {0}", name);
        }
    }

    /// <summary>
    /// 状态
    /// </summary>
    public abstract class State
    {
        private List<Transition> transitions = new List<Transition>();
        public List<Transition> Transitions
        {
            get { return transitions; }
        }

        private bool needUpdate = true;

        private string name;
        public string Name
        {
            get { return name; }
        }

        protected bool isInited = false;
        public bool IsInited
        {
            get { return isInited; }
			set { isInited = value;}
        }
		protected bool isEnter = false;
		public bool IsEnter
		{
			get { return isEnter; }
			set { isEnter = value;}
		}
		public void reset(FSM fsm)
		{
			isInited = false;
		}
        public State(string name)
        {
            this.name = name;
        }

        public List<Transition> GetTransition(string srcStateName, string targetStateName)
        {
            var result = new List<Transition>();
            for (int i = 0, len = transitions.Count; i < len; i++)
            {
                var t = transitions[i];
                if (t.SrcStateName == srcStateName && t.TargetStateName == targetStateName)
                    result.Add(t);
            }
            return result;
        }

        public void AddTransition(Transition value)
        {
            if (transitions.Contains(value))
                return;
            transitions.Add(value);
        }

        public void RemoveTransition(Transition value)
        {
            if (!transitions.Contains(value))
                return;
            transitions.Remove(value);
        }

        public override string ToString()
        {
            return string.Format("state name : {0}", name);
        }

        /// <summary>
        /// 如果调用之后，就会对Update执行一次
        /// </summary>
        public void DirtyState()
        {
            needUpdate = true;
        }

        public void Update(FSM fsm)
        {
            if (!isInited)
            {
                isInited = true;
                Init(fsm);
            }

            if (!needUpdate) return;
            needUpdate = false;

            foreach (var t in Transitions)
            {
                t.Update(fsm);
            }
        }
		public void Leave(FSM fsm)
		{
			IsEnter = false;
			isInited = false;
			LeaveState (fsm);
		}
		public void Enter(FSM fsm)
		{
			EnterState(fsm);
			IsEnter = true;
		}
        /// <summary>
        /// First time to Update will trigger
        /// </summary>
        protected abstract void Init(FSM fsm);

        public abstract void EnterState(FSM fsm);

        public abstract void LeaveState(FSM fsm);

        public abstract void Excute(FSM fsm);
    }

    /// <summary>
    /// 状态之间的过度处理(可包含多个过度管道)
    /// </summary>
    public class Transition
    {
        private string srcStateName;
        public string SrcStateName
        {
            get { return srcStateName; }
        }

        private string targetStateName;
        public string TargetStateName
        {
            get { return targetStateName; }
        }

        private List<Pipeline> pipelines = new List<Pipeline>();
        public List<Pipeline> Pipelines
        {
            get { return pipelines; }
        }

        public Transition(string srcStateName, string targetStateName)
        {
            this.srcStateName = srcStateName;
            this.targetStateName = targetStateName;
        }

        public List<Pipeline> GetPipeline(string srcStateName, string targetStateName)
        {
            var result = new List<Pipeline>();
            for (int i = 0, len = pipelines.Count; i < len; i++)
            {
                var t = pipelines[i];
                if (t.SrcStateName == srcStateName && t.TargetStateName == targetStateName)
                    result.Add(t);
            }
            return result;
        }

        public void AddPipeline(Pipeline pipeline)
        {
            if (pipelines.Contains(pipeline)) return;
            pipelines.Add(pipeline);
        }

        public void AddPipelines(List<Pipeline> pipelines)
        {
            foreach (var p in pipelines)
                AddPipeline(p);
        }

        public void RemovePipeline(Pipeline pipeline)
        {
            if (!pipelines.Contains(pipeline)) return;
            pipelines.Remove(pipeline);
        }

        public void Update(FSM fsm)
        {
            foreach (var p in Pipelines)
            {
                if (p.Check(fsm))
                {
                    fsm.SetCurState(p.TargetStateName);
                    return;
                }
            }
        }

        public void ClearPipelines()
        {
            pipelines.Clear();
        }
    }

    /// <summary>
    /// 状态之间的过度管道（可包含多个过度条件）
    /// 1.1版，修正了，对条件之间的控制为：&& ： 与关系
    /// </summary>
    public class Pipeline
    {
        private string srcStateName;
        public string SrcStateName
        {
            get { return srcStateName; }
        }

        private string targetStateName;
        public string TargetStateName
        {
            get { return targetStateName; }
            set { targetStateName = value; }
        }

        private List<Condition> conditions = new List<Condition>();

        public Pipeline(string srcStateName, string targetStateName)
        {
            this.srcStateName = srcStateName;
            this.targetStateName = targetStateName;
        }

        /// <summary>
        /// 调用该方法前，最好先调用CheckAndThrowException
        /// </summary>
        public Condition AddCondition(string name, object args, ConditionType type)
        {
            var result = new Condition(name, args, type);
            conditions.Add(result);
            return result;
        }

        public void AddConditions(List<Condition> conditions)
        {
            foreach (var c in conditions)
                AddCondition(c);
        }
        /// <summary>
        /// 调用该方法前，最好先调用CheckAndThrowException
        /// </summary>
        public void AddCondition(Condition condition)
        {
            if (conditions.Contains(condition))
                return;
            conditions.Add(condition);
        }

        public void RemoveCondition(int idx)
        {
            conditions.RemoveAt(idx);
        }

        public void RemoveCondition(Condition condition)
        {
            if (!conditions.Contains(condition))
                return;
            conditions.Remove(condition);
        }

        public bool Check(FSM fsm)
        {
            // 1.0的时候是这样的：“或”关系
            //foreach (var condition in conditions)
            //{
            //    if (condition.Check())
            //        return true;
            //}

            // 1.1改为：以下：“与”关系
            var result = true;
            foreach (var condition in conditions)
            {
                if (!condition.Check(fsm)) // 只要有一个不成立，则不通过
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }

    /// <summary>
    /// 状态之间过度管道中的单个过度条件
    /// </summary>
    public class Condition
    {
        private string paramName;
        public string ParamName
        {
            get { return paramName; }
        }

        private ConditionType conditionType;
        public ConditionType ConditionType
        {
            get { return conditionType; }
        }

        private object args;
        public object Args
        {
            get { return args; }
        }

        public Condition(string paramName, object args, ConditionType conditionType)
        {
            this.paramName = paramName;
            this.args = args;
            this.conditionType = conditionType;
        }

        public bool Check(FSM fsm)
        {
            if (string.IsNullOrEmpty(paramName))
                return false;
            
            var param = fsm.GetParam<Param>(paramName);
            if (param == null)
                return false;

            bool result = false;
            switch (param.Type)
            {
                case ParamType.Int:
                case ParamType.Float:
                case ParamType.Double:
                    var valueParam = fsm.GetParam<ParamValue>(paramName);
                    if (valueParam != null)
                    {
                        result = CheckDouble(Convert.ToDouble(valueParam.Value), Convert.ToDouble(args), this.conditionType);
                    }
                    break;
                case ParamType.Boolean:
                    var boolParam = fsm.GetParam<ParamBoolean>(paramName);
                    if (boolParam != null)
                    {
                        result = CheckBool(Convert.ToBoolean(boolParam.Value), Convert.ToBoolean(args), this.conditionType);
                    }
                    break;
                case ParamType.Func:
                    var funcParam = fsm.GetParam<ParamFunc>(paramName);
                    if (funcParam != null)
                    {
                        FuncParamHandler action = (FuncParamHandler)funcParam.Value;
                        object[] funcArgs = args == null ? null : (args is object[] ? args as object[] : new object[] { args });
                        result = action != null ? action(funcArgs) : false;
                    }
                    break;
				case ParamType.UnityGameObject:
					var objParam = fsm.GetParam<ParamValue>(paramName);
					if (objParam != null)
					{
						result = CheckGameObject((GameObject)objParam.Value, (GameObject)args, this.conditionType);
					}
					break;
				case ParamType.Str:
					var strParam = fsm.GetParam<ParamValue>(paramName);
					if (strParam != null)
					{
						//result = CheckString(Convert.ToString(objParam.Value), Convert.ToString(args), this.conditionType);
					}
					break;
                default:
                    throw new Exception(string.Format("PipelineCondition.Check(FSM fsm) paramName : {0}, paramType : {1} unhandler!", paramName, param.Type));
            }

            return result;
        }

        private static bool CheckBool(bool a, bool b, ConditionType type)
        {
            if (type == ConditionType.Equals)
                return a == b;
            else if (type == ConditionType.NotEquals)
                return a != b;
            return false;
        }
		private static bool CheckGameObject(GameObject a, GameObject b, ConditionType type)
		{
			if (type == ConditionType.Equals)
				return a == b;
			else if (type == ConditionType.NotEquals)
				return a != b;
			return false;
		}
		private static bool CheckString(String a, String b, ConditionType type)
		{
			if (type == ConditionType.Equals)
				return String.Compare(a, b) == 0 ? true : false;
			else if (type == ConditionType.NotEquals)
				return String.Compare(a, b) != 0 ? true : false;
			return false;
		}

        private static bool CheckInt(int a, int b, ConditionType type)
        {
            return CheckValueAndTarget(a, b, type);
        }

        private static bool CheckFloat(float a, float b, ConditionType type)
        {
            return CheckValueAndTarget(a, b, type);
        }

        private static bool CheckDouble(double a, double b, ConditionType type)
        {
            return CheckValueAndTarget(a, b, type);
        }

        private static bool CheckValueAndTarget(double value, double target, ConditionType type)
        {
            bool result = false;
            if (ContainType(type, ConditionType.Less))
            {
                result = value < target;
            }
            else if (ContainType(type, ConditionType.LessEquals))
            {
                result = value <= target;
            }
            else if (ContainType(type, ConditionType.Equals))
            {
                result = value == target;
            }
            else if (ContainType(type, ConditionType.Greater))
            {
                result = value > target;
            }
            else if (ContainType(type, ConditionType.GreaterEquals))
            {
                result = value >= target;
            }
            else if (ContainType(type, ConditionType.NotEquals))
            {
                result = value != target;
            }
            return result;
        }

        public static bool ContainType(ConditionType type, ConditionType beContainedType)
        {
            return (type & beContainedType) == beContainedType;
        }
    }

    /// <summary>
    /// 过度参数的成立条件类型
    /// </summary>
    [Flags]
    public enum ConditionType
    {
        None = 0,
        Less = 1,
        LessEquals = 2,
        Equals = 4,
        Greater = 8,
        GreaterEquals = 16,
        NotEquals = 32,
        Func = 64
    }

    /// <summary>
    /// 过度参数类型
    /// </summary>
    public enum ParamType
    {
        Int,
        Float,
        Double,
        Boolean,
		Str,
		UnityGameObject,
        Func
    }

    /// <summary>
    /// 过度参数是函数类型
    /// </summary>
    public class ParamFunc : Param
    {
        public ParamFunc(string name, Delegate func)
            : base(name, ParamType.Func)
        {
            Value = func;
        }
    }

    /// <summary>
    /// 过度参数是布尔类型
    /// </summary>
    public class ParamBoolean : Param
    {
        public ParamBoolean(string name)
            : base(name, ParamType.Boolean)
        {
            Value = false;
        }
    }

    /// <summary>
    /// 过度参数是值类型
    /// </summary>
    public class ParamValue : Param
    {
        public ParamValue(string name)
            : this(name, ParamType.Int)
        {

        }

        public ParamValue(string name, ParamType type)
            : base(name, type)
        {
            if (type == ParamType.Func)
                throw new Exception(string.Format("FSMParamValue type invalidated, type : {0}", type));
            switch (type)
            {
                case ParamType.Int:
                    Value = 0;
                    break;
                case ParamType.Float:
                    Value = 0f;
                    break;
                case ParamType.Double:
                    Value = 0d;
                    break;
				case ParamType.UnityGameObject:
					Value = null;
					break;
				case ParamType.Str:
					Value = "";
					break;
				case ParamType.Boolean:
					Value = false;
					break;
                default:
					Debug.Log(name + " " + type );
                    throw new Exception(string.Format("FSMParamValue new type : {0} unhandled", type));
				break;
            }
        }
    }

    /// <summary>
    /// 过度的参数类
    /// </summary>
    public abstract class Param
    {
        private static Dictionary<ParamType, ConditionType> dic = new Dictionary<ParamType, ConditionType>();
        public static ConditionType GetConditionTypeByParamType(ParamType type)
        {
            return dic[type];
        }

        static Param()
        {
            dic[ParamType.Int] =
            dic[ParamType.Float] =
            dic[ParamType.Double] = ConditionType.Less | ConditionType.LessEquals | ConditionType.Equals |
                                    ConditionType.Greater | ConditionType.GreaterEquals | ConditionType.NotEquals;
            dic[ParamType.Func] = ConditionType.Func;
            dic[ParamType.Double] = ConditionType.Equals | ConditionType.NotEquals;
			dic[ParamType.UnityGameObject] = ConditionType.Equals | ConditionType.NotEquals;
			dic[ParamType.Str] = ConditionType.Equals | ConditionType.NotEquals;
        }

        private string name;
        public string Name
        {
            get { return name; }
        }

        public ParamType Type;
        public object Value; // object Value 可以考虑使用FSMParam<T> => Generic Type

        public Param(string name, ParamType type)
        {
            this.name = name;
            this.Type = type;
        }

        public T GetValue<T>() where T : struct
        {
            return (T)Value;
        }

        public T GetClassValue<T>() where T:class
        {
            return Value as T;
        }

        public bool CheckValue() // self
        {
            return CheckValue(Value);
        }

        public bool CheckValue(object value) // sepecial
        {
            bool result = false;
            switch (Type)
            {
                case ParamType.Int:
                    result = value is int;
                    break;
                case ParamType.Float:
                    result = value is float;
                    break;
                case ParamType.Double:
                    result = value is double;
                    break;
                case ParamType.Boolean:
                    result = value is bool;
                    break;
                case ParamType.Func:
                    result = true; // func args, it can spectial anything..., always return true
                    break;
				case ParamType.UnityGameObject:
//					result = value != null ? true : false;
					result = true;
					break;
				case ParamType.Str:
					result = true;
					break;
            }
            return result;
        }

        public Param Clone()
        {
            return MemberwiseClone() as Param;
        }

        public override string ToString()
        {
            return string.Format("name : {0}, type : {1}, value : {2}", name, Type, Value);
        }
    }

    /// <summary>
    /// 黑板数据的更新类型
    /// </summary>
    public enum BlackboardUpdateType
    {
        Add,
        Remove,
        Modify
    }

    /// <summary>
    /// FSM中的黑板数据，便于，绑定外部数据，方便在FSM中对外部数据的获取与判断而使用
    /// 有点像BT（Behavior Tree）中的 Black board而设计
    /// </summary>
    public class Blackboard
    {
        private Dictionary<string, object> datasStore = new Dictionary<string, object>();

        public event Action<Blackboard, BlackboardUpdateType> UpdateEvent;

        private void OnUpdateEvent(BlackboardUpdateType updateType)
        {
            if (UpdateEvent != null)
            {
                UpdateEvent(this, updateType);
            }
        }

        public bool HaveDatas
        {
            get
            {
                return datasStore.Keys.Count > 0;
            }
        }

        public T GetData<T>(string name)
        {
            return (T)datasStore[name];
        }

        public void AddData(string name, object data)
        {
            var srcHad = datasStore.ContainsKey(name);
            datasStore[name] = data;
            OnUpdateEvent(srcHad ? BlackboardUpdateType.Modify : BlackboardUpdateType.Add);
        }

        public object RemoveData(string name)
        {
            if (!datasStore.ContainsKey(name))
                return null;
            object result = datasStore[name];
            datasStore.Remove(name);
            OnUpdateEvent(BlackboardUpdateType.Remove);
            return result;
        }

        public void UpdateData(string name)
        {
            if (!datasStore.ContainsKey(name))
                return;
            OnUpdateEvent(BlackboardUpdateType.Modify);
        }
    }
}