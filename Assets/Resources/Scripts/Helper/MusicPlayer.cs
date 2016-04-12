using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	string[] songNames = {"BarcelonaDreams", "FlamencoInfusion", "GuitarTwilight",
												"LunaYSol", "MysticOasis", "The EssenceofYou", "VivaEspana"};

	// Use this for initialization
	void Start () {

		int i = UnityEngine.Random.Range(0, songNames.Length);

		AudioSource song = GetComponent<AudioSource>();
		song.clip = Resources.Load("Music/"+songNames[i]) as AudioClip;
		song.Play();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
