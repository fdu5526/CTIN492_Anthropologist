using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	Text dialogueText;
	bool isActive;

	// Use this for initialization
	void Awake () {
		isActive = false;
		GetComponent<CanvasGroup>().alpha = 0f;
		dialogueText = transform.Find("Text").GetComponent<Text>();
	}



	IEnumerator Fade (bool fadeIn) {
		float duration = 1f;
		float startTime = Time.time;
		while (Time.time - startTime < duration) {
			float d = (Time.time - startTime) / duration;

			GetComponent<CanvasGroup>().alpha = fadeIn ? d : 1f - d;
			yield return 1;
		}
	}


	public void Activate (bool activate) {
		isActive = activate;
		StartCoroutine(Fade(activate));
	}


	public void SetText (string text) {
		dialogueText.text = text;
	}

	public void SetNarration (AudioClip clip) {
		AudioSource a = GetComponent<AudioSource>();
		a.clip = clip;
		a.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
