using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnAllSnapsCorrect : MonoBehaviour
{
	public SnapzoneLockGameObject[] snapzoneLockGameObjects;
	public UnityEvent onAllCorrect;
	
	void Reset()
	{
		snapzoneLockGameObjects = this.GetComponentsInChildren<SnapzoneLockGameObject>();
	}
	
	void Start()
	{
		for(int i = 0; i < snapzoneLockGameObjects.Length; i++)
		{
			snapzoneLockGameObjects[i].onCorrect.AddListener(CheckAll);
		}
	}
	
	public void CheckAll()
	{
		for(int i = 0; i < snapzoneLockGameObjects.Length; i++)
		{
			if(snapzoneLockGameObjects[i].Correct == false)
				return;
		}
		
		onAllCorrect.Invoke();
	}
}
