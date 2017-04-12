using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


	//Making the variables
	public Text scoreText;
	public Text hiScoreText;

	public float scoreCount;
	public float hiScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing; 




	// Use this for initialization
	void Start () {

		// if the player uses the key HighScore
		if(PlayerPrefs.HasKey("HighScore"))
			{
				// getting the highscore float
				hiScoreCount = PlayerPrefs.GetFloat("HighScore");
			}
	}
	
	// Update is called once per frame
	void Update () {
		// als de score verhoogd
		if (scoreIncreasing) {
			// scoreCount plus pointsPerSecond vermenigvuldigd met de Time.deltaTime
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		// als de scorecount groter is dan de highscoreCount
		if (scoreCount > hiScoreCount) 
		{
			// dan word de highscorecount verhoogd
			hiScoreCount = scoreCount;
			// verander de opgeslagen highscore naar de hiscore variabele
			PlayerPrefs.SetFloat ("HighScore", hiScoreCount);
		}
		// geeft de text weer op het scherm
		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiScoreText.text = "High Score: " + Mathf.Round (hiScoreCount);

	}
}
