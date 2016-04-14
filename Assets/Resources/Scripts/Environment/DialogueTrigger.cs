using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	DialogueBox dialogueBox;

	[SerializeField]
	int storyNumber;

	string text;

	// Use this for initialization
	void Awake () {
		dialogueBox = GameObject.Find("Canvas/DialogueBox").GetComponent<DialogueBox>();
		text = Resources.Load<TextAsset>("Texts/story" + storyNumber).text;
	}


	void OnTriggerEnter2D (Collider2D other) {
		dialogueBox.Activate(true);
		dialogueBox.SetText(text);
	}

	void OnTriggerExit2D (Collider2D other) {
		dialogueBox.Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
