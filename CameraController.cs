using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerController thePlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
	// vind de playerscript
		thePlayer = FindObjectOfType<PlayerController> ();
		// geef aan dat de lastPlayerPosition dezelfde positie  is als de speler bij de start
		lastPlayerPosition = thePlayer.transform.position;
	

	}
	
	// Update is called once per frame
	void Update () {
		// de distance die de camera moet zijn is het zelfde als de x positie van de player
		distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;
		// verander de positie van de camera
		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = thePlayer.transform.position;
		                                          
	}
}
