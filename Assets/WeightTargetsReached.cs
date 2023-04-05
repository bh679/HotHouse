﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightTargetsReached : MonoBehaviour
{
	public WeightTarget[] targets;
	public bool runOnce = true;
	bool alreadyRun = false;
	
	public UnityEvent onAllReached;
	
    
	void Reset()
    {
	    targets = this.GetComponentsInChildren<WeightTarget>();
    }

    // Update is called once per frame
    void Update()
    {
	    if(((alreadyRun && runOnce) || !runOnce) && CheckFound())
	    {
	    	onAllReached.Invoke();
	    	alreadyRun = true;
	    }
    }
    
	public bool CheckFound()
	{
		for(int i =0 ;i < targets.Length; i++)
		{
			if(!targets[i].found)
				return false;
		}
		
		return true;
	}
}
