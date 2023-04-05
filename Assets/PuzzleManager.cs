using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
	
	public int puzzlesComplete = 0;
	
	public UnityEvent onFirst, onSecond, onThird;
	
	public void CompletePuzzle()
	{
		puzzlesComplete++;
		
		switch(puzzlesComplete)
		{
		case 0:
			onFirst.Invoke();
			break;
			
		case 1:
			onSecond.Invoke();
			break;
			
		case 2:
			onThird.Invoke();
			break;
			
		}
	}
}
