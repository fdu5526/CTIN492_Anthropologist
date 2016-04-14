using UnityEngine;
using System.Collections;

public class IndoorTrigger : MonoBehaviour {
	[SerializeField]
	bool transitionToIndoor;

	Player player;
	MainCamera mainCamera;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").GetComponent<Player>();
		mainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
	}


	void OnTriggerExit2D (Collider2D other) {
		player.isIndoors = transitionToIndoor;
		mainCamera.SwitchIndoors(transitionToIndoor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
