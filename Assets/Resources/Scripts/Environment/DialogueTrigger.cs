using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	DialogueBox dialogueBox;

	// Use this for initialization
	void Start () {
		dialogueBox = GameObject.Find("Canvas/DialogueBox").GetComponent<DialogueBox>();
	}


	void OnTriggerStay2D (Collider2D other) {
		dialogueBox.Activate(true);
	}

	void OnTriggerExit2D (Collider2D other) {
		dialogueBox.Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
