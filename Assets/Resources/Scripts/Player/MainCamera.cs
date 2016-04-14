using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	GameObject player;
	AudioClip[] ambiences;

	// Use this 	for initialization
	void Start () {
		player = GameObject.Find("Player").gameObject;
		ambiences = new AudioClip[2];
		ambiences[0] = Resources.Load<AudioClip>("Sounds/Environment/windLoop");
		ambiences[1] = Resources.Load<AudioClip>("Sounds/Environment/hum");
	}


	public void SwitchIndoors (bool isInDoors) {
		if (isInDoors) {
			GetComponent<AudioSource>().clip = ambiences[1];
		} else {
			GetComponent<AudioSource>().clip = ambiences[0];
		}
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pp = player.transform.position;
		GetComponent<Transform>().position = new Vector3(pp.x, pp.y, -10f);

	}
}
