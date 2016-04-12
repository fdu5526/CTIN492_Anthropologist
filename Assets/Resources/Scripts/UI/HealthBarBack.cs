using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarBack : MonoBehaviour {

	Slider healthBar;
	float rate = 0.5f;

	// Use this for initialization
	void Start () {
		healthBar = GameObject.Find("Canvas/HealthBar").GetComponent<Slider>();
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		float v = GetComponent<Slider>().value;
		if (healthBar.value < v) {
			GetComponent<Slider>().value = Mathf.Max(healthBar.value, v - rate);
		}
	}
}
