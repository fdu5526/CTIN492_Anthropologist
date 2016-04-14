using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	GameObject player;
	AudioClip[] ambiences;
	ParticleSystem snow;

	// Use this 	for initialization
	void Start () {
		player = GameObject.Find("Player").gameObject;
		ambiences = new AudioClip[2];
		ambiences[0] = Resources.Load<AudioClip>("Sounds/Environment/windLoop");
		ambiences[1] = Resources.Load<AudioClip>("Sounds/Environment/hum");
		snow = transform.Find("Snow").GetComponent<ParticleSystem>();
	}

	public void SwitchIndoors (bool isInDoors) {
		if (isInDoors) {
			GetComponent<AudioSource>().clip = ambiences[1];
			snow.Stop();
		} else {
			GetComponent<AudioSource>().clip = ambiences[0];
			snow.Play();
		}
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 pp = player.transform.position;
		GetComponent<Transform>().position = new Vector3(pp.x, pp.y, -10f);

	}
}
