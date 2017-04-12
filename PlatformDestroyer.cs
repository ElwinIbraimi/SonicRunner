using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {

		//zoeken naar object met de naam PlatformDestructionPoint
		platformDestructionPoint = GameObject.Find ("PlatformDestructionPoint");

	}
	
	// Update is called once per frame
	void Update () {
	
		//Als de platform te ver weg is van het object, word het platform vernietigd
		if (transform.position.x < platformDestructionPoint.transform.position.x) 
		{

			//Destroy (gameObject);

			gameObject.SetActive(false);

		}

	}
}
