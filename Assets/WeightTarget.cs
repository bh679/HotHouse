using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightTarget : MonoBehaviour
{
	public Material foundMat, notFoundMat;
	public Scale scale;
	public List<Weight> targets;
	public bool found = false;
	public MeshRenderer light;
	
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
			found = true;
			
			light.material = foundMat;
		}
	}
}
