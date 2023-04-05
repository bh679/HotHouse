using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BNG;

public class Puzzle2 : MonoBehaviour
{
	public Lever level;
	public UnityEvent onComplete;
	bool leverDown;
	bool complete = false;
	
	public void Start()
	{
		level.onLeverDown.AddListener(()=>{leverDown = true;});
		level.onLeverUp.AddListener(()=>{leverDown = false;});
	}
	
	public void CheckLever()
	{
		if(complete)
			return;
			
		if(leverDown)
		{
			onComplete.Invoke();
			complete = true;
		}
	}
}
