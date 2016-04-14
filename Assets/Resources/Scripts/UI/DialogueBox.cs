using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	Text dialogueText;

	// Use this for initialization
	void Awake () {
		Activate(false);
		dialogueText = transform.Find("Text").GetComponent<Text>();
	}


	public void Activate (bool activate) {
		GetComponent<CanvasGroup>().alpha = activate ? 1f : 0f;
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
