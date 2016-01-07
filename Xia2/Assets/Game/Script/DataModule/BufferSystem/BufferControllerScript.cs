using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BufferControllerScript : MonoBehaviour {
	BufferController bufferController;
	
	void Awake(){
		bufferController = new BufferController();
		Init();
	}
	
	Unit baseUnit;
	
	void Update(){
		bufferController.Update();
	}
	
	public void Init(){
		baseUnit = (Unit)GetComponent(typeof(Unit));
		bufferController.Init(baseUnit);
	}
	
	Unit GetBaseUnit(){return baseUnit;}
	
	public void AddOneBufferById(int id , Transform effect){
		//bufferController.AddOneBufferById(id , effect);
	}
	
	public void RemoveBufferById(int id){
		bufferController.RemoveBufferById(id);
	}
	
	public void RemoveAllBuffer(){
		bufferController.RemoveAllBuffer();
	}
	
	public void HideAllEffect(){
		bufferController.HideAllEffect();
	}
	
	public void ShowAllEffect(){
		bufferController.ShowAllEffect();
	}
	
	public bool AbsorbDamage(float damage){
		return bufferController.AbsorbDamage(damage);
	}

	
	public void AddAttackByHp(){
		bufferController.AddAttackByHp();
	}
		
	void OnDestory(){
		RemoveAllBuffer();
		HideAllEffect();
	}
}