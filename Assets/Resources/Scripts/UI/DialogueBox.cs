using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	Text dialogueText;

	// Use this for initialization
	void Start () {
		Activate(false);
	}


	public void Activate (bool activate) {
		GetComponent<CanvasGroup>().alpha = activate ? 1f : 0f;
	}


	public void SetText (string text) {
		dialogueText.text = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
