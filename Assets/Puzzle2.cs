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
	
	public void Start()
	{
		level.onLeverDown.AddListener(()=>{leverDown = true;});
		level.onLeverUp.AddListener(()=>{leverDown = false;});
	}
	
	public void CheckLever()
	{
		if(leverDown)
			onComplete.Invoke();
	}
}
