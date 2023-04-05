using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeightTarget : MonoBehaviour
{
	public Material foundMat, notFoundMat;
	public Scale scale;
	public List<Weight> targets;
	public bool found = false;
	public MeshRenderer light;
	public bool useTarget;
	public UnityEvent onFound;
	
	void Start()
	{
		light.material = notFoundMat;
		scale.onTriggerEnterEvent.AddListener(()=>{CheckTarget();});
	}
	
	public void CheckTarget()
	{
		Debug.Log("Checking " + scale.target);
		
		if(found)
			return;
			
		if(targets.Contains(scale.target))
		{
			if(useTarget)
				if(scale.target.weight != scale.target.targetWeight)
					return;
					
			found = true;
			
			light.material = foundMat;
			
			onFound.Invoke();
		}
	}
}
