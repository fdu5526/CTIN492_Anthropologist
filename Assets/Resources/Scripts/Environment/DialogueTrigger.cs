using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour {
	DialogueBox dialogueBox;

	[SerializeField]
	int storyNumber;

	float[] timings;
	string[] texts;
	AudioClip clip;

	bool started;
	int currentIndex;
	float startTime;

	// Use this for initialization
	void Awake () {
		dialogueBox = GameObject.Find("Canvas/DialogueBox").GetComponent<DialogueBox>();
		clip = Resources.Load<AudioClip>("Sounds/Story/story" + storyNumber);


		string s = Resources.Load<TextAsset>("Texts/story" + storyNumber).text;
		string[] data = s.Split('\n');
		Debug.Assert(data.Length % 2 == 0);
		
		texts = new string[data.Length / 2];
		for (int i = 0; i < texts.Length; i++) {
			texts[i] = data[i * 2];
		}

		timings = new float[data.Length / 2];
		for (int i = 0; i < timings.Length; i++) {
			timings[i] = float.Parse(data[i * 2 + 1]);
		}

	}


	public void Stop () {
		started = false;
	}


	void OnTriggerEnter2D (Collider2D other) {

		DialogueTrigger[] d = FindObjectsOfType(typeof(DialogueTrigger)) as DialogueTrigger[];
		for (int i = 0; i < d.Length; i++) {
			d[i].Stop();
		}

		started = true;
		currentIndex = 0;
		startTime = Time.time;
		dialogueBox.Activate(true);
		dialogueBox.SetText(texts[currentIndex]);
		dialogueBox.SetNarration(clip);
		GetComponent<Collider2D>().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (started) {
			if (Time.time - startTime > timings[currentIndex]) {
				currentIndex++;
				if (currentIndex >= timings.Length) {
					started = false;
					dialogueBox.Activate(false);
				} else {
					dialogueBox.SetText(texts[currentIndex]);
				}
			}
		}
	}
}
