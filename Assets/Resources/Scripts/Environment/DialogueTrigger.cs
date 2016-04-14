using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	DialogueBox dialogueBox;

	[SerializeField]
	int storyNumber;

	string text;
	AudioClip clip;

	// Use this for initialization
	void Awake () {
		dialogueBox = GameObject.Find("Canvas/DialogueBox").GetComponent<DialogueBox>();
		text = Resources.Load<TextAsset>("Texts/story" + storyNumber).text;
		clip = Resources.Load<AudioClip>("Sounds/Story/story" + storyNumber);
	}


	void OnTriggerStay2D (Collider2D other) {
		if (Input.GetKey("e")) {
			dialogueBox.Activate(true);
			dialogueBox.SetText(text);
			GetComponent<Collider2D>().enabled = false;
			dialogueBox.SetNarration(clip);
			transform.Find("Prompt").gameObject.SetActive(false);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		dialogueBox.Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
