using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BrennanHatton.UnityTools.LegacyUI
{

	public class TMPTextFade : MonoBehaviour
	{
		public TMP_Text text;
		
		Color textColor;
		
		void Reset()
		{
			text= this.GetComponent<TMP_Text>();
		}
		
		void Start()
		{
			textColor = text.color;
		}
		
		public void StartAppear(float time)
		{
			if(text.isActiveAndEnabled)
				StartCoroutine(Appear(time));
		}
		
		IEnumerator Appear(float time)
		{
			for(int i = 0; i < time*10; i++)
			{
				yield return new WaitForSeconds(0.1f);
				//Debug.Log(i/(time*10) + " " + text.color.maxColorComponent);
				text.color = new Color(textColor.r,textColor.g,textColor.b,i/(time*10));
			}
			text.color = new Color(textColor.r,textColor.g,textColor.b,255);
		}
		
		public void StartDisappear(float time)
		{
			if(text.isActiveAndEnabled)
				StartCoroutine(Disappear(time));
		}
		
		IEnumerator Disappear(float time)
		{
			for(int i = 0; i < time*10; i++)
			{
				yield return new WaitForSeconds(0.1f);
				
				text.color = new Color(textColor.r,textColor.g,textColor.b,1-i/(time*10));
			}
			text.color = new Color(textColor.r,textColor.g,textColor.b,0);
		}
	}

}