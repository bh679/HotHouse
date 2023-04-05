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
		case 1:
			onFirst.Invoke();
			break;
			
		case 2:
			onSecond.Invoke();
			break;
			
		case 3:
			onThird.Invoke();
			break;
			
		}
	}
}
