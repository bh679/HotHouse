using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Scale : MonoBehaviour
{
	public List<GameObject> targets= new List<GameObject>();
	public List<GameObject> excludes= new List<GameObject>();
	public LayerMask layer;
	public UnityEvent onTriggerEnterEvent;
	public UnityEvent onTriggerStayEvent;
	public UnityEvent onTriggerExitEvent;
	public bool useStay = false;
	
	public TMP_Text displayText;
	
	public Weight target;
	
	public string weight = "0.0";
	public string measurement = "kg";
	public string tooManyItemsMessage = "Too many items";
	public string errorMessage = "invalid";
	public string defaultMessage = "0.0 kg";
	
	void Start()
	{
		weight = defaultMessage;
		displayText.text = weight;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			if(excludes.Contains(other.gameObject))
			{
				return;
			}
			
			WeightCalc(other);
			
			//Debug.Log(other);
			onTriggerEnterEvent.Invoke();
		}
	}
    
	void WeightCalc(Collider other)
	{
		/*if(target != null && target != other)
		{
			//weight = tooManyItemsMessage;
			Debug.Log(tooManyItemsMessage);
		}
		else{*/
				
		target = other.gameObject.GetComponent<Weight>();
			
		if(target == null)
			weight = errorMessage;
		else
			weight = target.weight.ToString() + measurement;
		//}
		
		displayText.text = weight;
			
	}
    
	private void OnTriggerStay(Collider other)
	{
		if(!useStay)
			return;
			
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			if(excludes.Contains(other.gameObject))
			{
				return;
			}
			
			Weight weightT = other.gameObject.GetComponent<Weight>();
		
			if(weightT != null)
				target = weightT;
			
			if(target == null)
				weight = errorMessage;
			else
				weight = target.weight.ToString() + measurement;
			//}
		
			displayText.text = weight;
			
			//Debug.Log(other);
			onTriggerStayEvent.Invoke();
		}
	}
    
	private void OnTriggerExit(Collider other)
	{
		
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			if(excludes.Contains(other.gameObject))
			{
				return;
			}
			//Debug.Log(other);
			onTriggerExitEvent.Invoke();
		}
		
		target = null;
		
		weight = defaultMessage;
		displayText.text = weight;
	}
}
