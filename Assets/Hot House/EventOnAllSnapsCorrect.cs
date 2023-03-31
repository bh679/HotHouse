using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAllSnapsCorrect : MonoBehaviour
{
	public SnapzoneLockGameObject[] snapzoneLockGameObjects;
	public UnityEvent onAllCorrect;
	public bool autoCheck = true;
	
	void Reset()
	{
		snapzoneLockGameObjects = this.GetComponentsInChildren<SnapzoneLockGameObject>();
	}
	
	void Start()
	{
		if(!autoCheck)
			return;
			
		for(int i = 0; i < snapzoneLockGameObjects.Length; i++)
		{
			snapzoneLockGameObjects[i].onCorrect.AddListener(CheckAll);
		}
	}
	
	public void CheckAll()
	{
		Debug.Log("CheckAll");
		for(int i = 0; i < snapzoneLockGameObjects.Length; i++)
		{
			if(snapzoneLockGameObjects[i].Correct == false)
				return;
		}
		
		Debug.Log("onAllCorrect.Invoke");
		onAllCorrect.Invoke();
	}
}
