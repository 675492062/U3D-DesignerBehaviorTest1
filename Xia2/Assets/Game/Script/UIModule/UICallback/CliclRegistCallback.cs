using UnityEngine;
using System.Collections;

public class CliclRegistCallback : MonoBehaviour {
    public UIInput UserNameInput;
    public UIInput PasswordInput;
    public UIInput ConfirmInput;
    public UIInput MailInput;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
		string name = UserNameInput.value;			//账号
		/**  校验账号 */
		if (string.IsNullOrEmpty (name)) 
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.NAMEISNULL);
			}
			return;		
		}
		string password = PasswordInput.value;				//密码
		/**  校验密码 */
		if (string.IsNullOrEmpty (password)) 
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.PASSWORDISNULL);
			}
			return;		
		}
		string confirmPassword = ConfirmInput.value;		// 确认密码
		/**  校验确认密码*/
		if (string.IsNullOrEmpty (confirmPassword)) 
		{
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.CONFIRMPASSWORDISNULL);
			}
			return;		
		}
		/**  密码不一致 */
		if (!confirmPassword.Equals (password)) {
			ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
			if (err != null)
			{
				err.showErrorWindow();
				err.setErrorText(GlobalDef.PASSWORDOINCONFORMITY);
			}
			return;	
		}
        string str_Email = "";
        bool check = CheckIsMailFormat(MailInput.value);
        if (check)
        {
            str_Email = MailInput.value;
        }
        else
        {
            ErrorParse err = (ErrorParse)FindObjectOfType(typeof(ErrorParse));
            if (err != null)
            {
                err.showErrorWindow();
                err.setErrorText(GlobalDef.MAILERROR);
            }
            return;
        }
        PlayerPrefs.SetString("username", UserNameInput.value);
        PlayerPrefs.SetString("password", PasswordInput.value);
        var httpMsg = (HttpMsgManager)FindObjectOfType(typeof(HttpMsgManager));
        if (httpMsg)
        {
			httpMsg.register(name, PasswordInput.value, str_Email);//执行注册协议
        }
    }

    bool CheckIsMailFormat(string strValue)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(strValue, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
}
