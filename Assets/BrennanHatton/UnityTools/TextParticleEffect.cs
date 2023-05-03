using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(ParticleSystem))]
public class TextParticleEffect : MonoBehaviour
{
	public string textToDisplay;
	public float createTime;
	public float hoverTime;
	public float disassembleTime;

	private ParticleSystem _particleSystem;
	private TMP_Text _textMeshPro;

	private void Start()
	{
		_particleSystem = GetComponent<ParticleSystem>();
		_textMeshPro = GetComponentInChildren<TMP_Text>();

		StartCoroutine(PlayTextEffect());
	}

	private IEnumerator PlayTextEffect()
	{
		// Set up text
		_textMeshPro.text = textToDisplay;
		_textMeshPro.ForceMeshUpdate();

		// Create the particle effect
		/*var main = _particleSystem.main;
		main.duration = createTime;
		_particleSystem.Play();*/

		// Wait for the create time
		yield return new WaitForSeconds(createTime);

		// Hover the text
		_textMeshPro.enabled = true;
		yield return new WaitForSeconds(hoverTime);

		// Disassemble the text
		_textMeshPro.enabled = false;
		//_particleSystem. = new ParticleSystem.MinMaxCurve(0, disassembleTime);
		_particleSystem.Emit(_textMeshPro.textInfo.characterCount);

		// Wait for the disassemble time and stop the particle system
		yield return new WaitForSeconds(disassembleTime);
		_particleSystem.Stop();
	}
}
