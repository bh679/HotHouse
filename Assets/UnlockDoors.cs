using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class UnlockDoors : MonoBehaviour
{
	public DoorHelper[] doors;
	
	public void UnLock()
	{
		for(int i = 0; i < doors.Length; i++)
		{
			doors[i].DoorIsLocked = false;
		}
	}
}
