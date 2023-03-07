using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

public class SnapzoneLockGameObject : MonoBehaviour
{
	public Grabbable target;
	public UnityEvent onCorrect, onIncorrect;
	public SnapZone snapZone;
	bool correct = false;
	public bool Correct{get{return correct;}}
	
	void Reset()
	{
		snapZone = this.GetComponent<SnapZone>();
	}
	
	void Start()
	{
		snapZone.OnSnapEvent.AddListener(CheckIfCorrectGameObject);
	}
	
	public void CheckIfCorrectGameObject(Grabbable grabbable)
	{
		if(grabbable == target)
		{
			snapZone.CanRemoveItem = false;
			snapZone.CanDropItem = false;
			snapZone.CanSwapItem = false;
			correct = true;
			onCorrect.Invoke();
		}else
			onIncorrect.Invoke();
	}
}
