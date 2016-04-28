using UnityEngine;
using System.Collections;

public class RandomStartRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float randZ = UnityEngine.Random.Range(-40f, 40f);
		Vector3 r = transform.eulerAngles;

		transform.eulerAngles = new Vector3(r.x, r.y, r.z + randZ);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
