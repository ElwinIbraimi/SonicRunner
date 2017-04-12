using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	//Alle variabele aanmaken
	AudioSource audio;

	public float moveSpeed;
	private float moveSpeedStore;
	public float speedMultiplier;
	private float speedIncreaseMilestoneStore;
	public float speedIncreaseMilestone;
	private float speedMilestoneCount;
	private float speedMilestoneCountStore;
	public float emeraldCount = 5f;
	public float jumpForce;
	public float jumpTime;
	private float jumpTimeCounter;
	private Rigidbody2D myRigidbody;
	public static bool grounded;
	public LayerMask whatIsGround;
	private Collider2D myCollider;
	private Animator myAnimator;
	public GameManager theGameManager;
	private ScoreManager thisScoreManager;
	public AudioClip geluid1;
	public AudioClip geluid2;
	public AudioClip geluid3;
	public AudioClip geluid4;


	// Use this for initialization
	void Start () {
		//Als de game is opgestart voert de console het volgende uit
		myRigidbody = GetComponent<Rigidbody2D> ();
		myCollider = GetComponent<Collider2D> ();
		myAnimator = GetComponent<Animator> ();
		// jumpTimeCounter is gelijk aan jumpTime
		jumpTimeCounter = jumpTime;
		// speedMilestonecount is gelijk aan speedIncreaseMilestone
		speedMilestoneCount = speedIncreaseMilestone;
		moveSpeedStore = moveSpeed;
		speedMilestoneCountStore = speedMilestoneCount;
		speedIncreaseMilestoneStore = speedIncreaseMilestone;
		// de variabele audio 
		audio  = GetComponent<AudioSource>();
		GetComponent<AudioSource> ().clip = geluid1;
		GetComponent<AudioSource> ().Play ();
		thisScoreManager = FindObjectOfType<ScoreManager> ();


	}
	
	// Update is called once per frame
	void Update () {



		// grounded is als de player de layer grounded aan raakt
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		// als de x positie groter is dan de speedMilestoneCount
		if (transform.position.x > speedMilestoneCount) {
			// dan krijgt de speedMilestoneCount dezelfde waarde als speedIncreaseMilestone
			speedMilestoneCount += speedIncreaseMilestone;
			// en dan word de snelheid vermenigvuldigd met de speedMultiplier
			moveSpeed = moveSpeed * speedMultiplier;
		}

		// de player krijgt een snelheid toegewezen
		myRigidbody.velocity = new Vector2 (moveSpeed,myRigidbody.velocity.y);
		// als je op spatie drukt of op Linker Muis Knop 
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ){
			// als je op de grond staat
			if(grounded){
				// dan springt de player met een aangegeven waarde (jumpForce)
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}
				
		}
		// als je op spatie klikt of op linker muisknop
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0)){
			// als de jumpTimeCounter groter is dan 0
			if (jumpTimeCounter > 0){
				// dan springt de player met een aangegeven waarde
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;

			}
		}
		// als je op spatie klikt of op Linker Muis Knop
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) {
			// dan word de jumpTimeCounter 0
			jumpTimeCounter = 0;
		}
		// als je op de grond staat
		if (grounded) {
			// word de variabele jumpTimeCounter hetzelfde als de jumpTime
			jumpTimeCounter = jumpTime;
		}
		// hier maak ik floats aan voor de animator 
		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x);
		myAnimator.SetBool ("Grounded", grounded);

	}
	// als je de tag grond aanraakt dan is grounded true
	void OnTriggerEnter2D (Collider2D other){
		


		// als de player in de is en een enemy aanraakt met de tag kill
		if (other.gameObject.tag == "kill" && grounded == false) {
			// dan is die enemy er niet meer
			other.gameObject.SetActive (false);
			// als je op de grond staat en je raakt een enemy aan met de tag kill
		} if (other.gameObject.tag == "kill" && grounded == true) {
			// dan restart het spel
			theGameManager.RestartGame ();

		}
		if (other.gameObject.tag == "emerald") {
			other.gameObject.SetActive (false);
			thisScoreManager.scoreCount += emeraldCount;

		}

		// als je tegen de tag killbox aanloopt
		if (other.gameObject.tag == "killbox"){
			// maak een nieuwe random range variabele aan
			float random = Random.Range (1, 4);
			// restart het spel
			theGameManager.RestartGame ();
			// je movespeed variabele word hetzelfde als moveSpeedStore
			moveSpeed = moveSpeedStore;
			speedMilestoneCount = speedMilestoneCountStore;
			speedIncreaseMilestone = speedIncreaseMilestoneStore;

		
			// als de random range een getal pakt van 1 dan speelt het een aangegeven audioclip af
			if (random == 1){
			GetComponent<AudioSource> ().clip = geluid1;
			GetComponent<AudioSource> ().Play ();
			}
			// als de random range een getal pakt van 2 dan speelt het een aangegeven audioclip af
			if (random == 2){
				GetComponent<AudioSource> ().clip = geluid2;
				GetComponent<AudioSource> ().Play ();
			}
			// als de random range een getal pakt van 3 dan speelt het een aangegeven audioclip af
			if (random == 3){
				GetComponent<AudioSource> ().clip = geluid3;
				GetComponent<AudioSource> ().Play ();
			}
			// als de random range een getal pakt van 4 dan speelt het een aangegeven audioclip af
			if (random == 4){
				GetComponent<AudioSource> ().clip = geluid4;
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
}
