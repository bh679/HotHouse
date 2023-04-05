using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weight : MonoBehaviour
{
	public float weight = 1f;
	
	public float targetWeight = 1f;
	public UnityEvent onChangeWeight = new UnityEvent();
	
	public void ChangeWeightToTarget()
	{
		weight = targetWeight;
		
		onChangeWeight.Invoke();
	}
	
	public void ReduceWeightBy(float weightToReduce)
	{
		weight -= weightToReduce;
		
		onChangeWeight.Invoke();
	}
}
