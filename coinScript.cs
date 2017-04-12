using UnityEngine;
using System.Collections;

public class coinScript : MonoBehaviour {
	public AudioClip geluidCoin;
	private ScoreManager theScoreManager;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		// pakt de audiosource van het object
		audio  = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// als er iets in de trigger komt van de coin
	void OnTriggerEnter2D (Collider2D other){
		// als het gene dat in de trigger komt de tag Player heeft
		if (other.gameObject.tag == "Player") {
			// gebeurt er niks, het is useless deze script kan weg
		}
	}
}
