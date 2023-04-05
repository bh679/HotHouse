using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightChanger : MonoBehaviour
{
	public List<GameObject> targets= new List<GameObject>();
	public List<GameObject> excludes= new List<GameObject>();
	public LayerMask layer;
	public UnityEvent onTriggerEnterEvent;
	
	private void OnTriggerEnter(Collider other)
	{
		
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			if(excludes.Contains(other.gameObject))
			{
				return;
			}
			
			Weight weightObj = other.gameObject.GetComponent<Weight>();
			
			if(weightObj == null)
				Debug.LogError("No Weight Found");
			else
				weightObj.ChangeWeightToTarget();
			
			//Debug.Log(other);
			onTriggerEnterEvent.Invoke();
		}
	}
    
	
}
