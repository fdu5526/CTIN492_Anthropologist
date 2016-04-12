using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HurtPanel : MonoBehaviour {

	float maxTransparency;
	float prevHitTime;
	float stayOnTime;
	bool isActive;

	// Use this for initialization
	void Start () {
		isActive = false;
		prevHitTime = 0f;
		maxTransparency = GetComponent<Image>().color.a;
		GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
	}


	IEnumerator Activate (bool isActivating) {
		for (float f = maxTransparency; f >= 0f; f -= 0.02f) {
			if (isActive) {
				break;
			}
			Color c = GetComponent<Image>().color;
			c.a = isActivating ? maxTransparency - f : f;
			GetComponent<Image>().color = c;
			yield return new WaitForSeconds(0.01f);
		}
	}

	public void TurnOnForSeconds(float s) {
		isActive = true;
		stayOnTime = s;
		prevHitTime = Time.time;
		GetComponent<Image>().color = new Color(1f, 1f, 1f, maxTransparency);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isActive && Time.time - prevHitTime > stayOnTime) { // turn off panel after a while
			isActive = false;
			StartCoroutine(Activate(false));
		}
	}
}
