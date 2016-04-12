using UnityEngine;
using System.Collections;

public class FootstepParticle : MonoBehaviour {

	public float transparency = 1f;
	public float decayRate = 0.02f;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (transparency < 0f) {
		} else {
			transparency -= decayRate;
			Color c = GetComponent<SpriteRenderer>().color;
			c.a = transparency;
			GetComponent<SpriteRenderer>().color = c;	
		}
	}
}
