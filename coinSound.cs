using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class coinSound : MonoBehaviour {

	private float clipEnd; // declare this outside any function

	// deze script heb ik van internet
	void MyPlayOneShot(AudioClip sound){
		if (Time.time > clipEnd){ // if previous clip not playing anymore...
			audio.PlayOneShot(spring); // play the new one...
			clipEnd = Time.time + spring.length; // and calculate its end time
		}
	}
	// variabele aanmaken
	AudioSource audio;
	public AudioClip geluidCoin;
	public AudioClip spring;
	// Use this for initialization
	void Start () {
		// pak de AudioSource van het gameobject waar deze script op staat
		audio  = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// als je op spatie klikt of op Linker Muis Knop en de boolean grounded is waar
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0) && PlayerController.grounded == true){
			// speel een keer het aangegeven geluid af: spring;
				MyPlayOneShot(spring);
			
		}
	}
	void OnTriggerEnter2D (Collider2D other){
		// als je collide met een object dat de tag emerald heeft
		if (other.gameObject.tag == "emerald") {
			// speel het aangegeven geluid af.
			GetComponent<AudioSource> ().clip = geluidCoin;
			GetComponent<AudioSource> ().Play ();

		}
	}
}

