using UnityEngine;
using System.Collections;

public class IndoorTrigger : MonoBehaviour {
	[SerializeField]
	bool transitionToIndoor;

	Player player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
	}


	void OnTriggerExit2D (Collider2D other) {
		player.isIndoors = transitionToIndoor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
