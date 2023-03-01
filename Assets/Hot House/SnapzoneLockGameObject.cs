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
			onCorrect.Invoke();
		}else
			onIncorrect.Invoke();
	}
}
