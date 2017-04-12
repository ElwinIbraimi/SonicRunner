using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	//Maakt alle variabele aan
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;


	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler theObjectPool;

	public GameObject [] thePlatforms;
	private int platformSelector;
	private float[] platformWidths;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;


	public float randomSpikeThreshold;
	public ObjectPooler spikePool;

	public float randomCoinThreshold;
	public ObjectPooler coinPool;


	// Use this for initialization
	void Start () {
	
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;

		platformWidths = new float[thePlatforms.Length];

		for (int i = 0; i < thePlatforms.Length; i++) 
		{
			platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.x < generationPoint.position.x) 
		
		{
			//neemt een random getal tussen de aangegeven getallen van DistanceBetweenMin en Max
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, thePlatforms.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) 
			{
				heightChange = maxHeight;
			} 

			else if (heightChange < minHeight)

			{
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + platformWidths[platformSelector] + distanceBetween, heightChange, transform.position.z);



			//Instantiate (/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);

			GameObject newPlatform = theObjectPool.GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

		}
		// als de random range kleiner is dan de spikeThreshold
		if (Random.Range (0f, 100f) < randomSpikeThreshold) 
		{
			// pak de enemy
			GameObject newSpike = spikePool.GetPooledObject();
			// maak een nieuwe variabele aan
			float spikeXposition = Random.Range (5,10);
			// gebruik de aangemaakte variabele om te bepalen waar de enemy spawnt
			Vector3 spikePosition = new Vector3(spikeXposition, 0.5f, 0f);

			newSpike.transform.position = transform.position + spikePosition;
			newSpike.transform.rotation = transform.rotation;
			newSpike.SetActive(true);
		}
		if (Random.Range (0f, 100f) < randomCoinThreshold) 
		{
			GameObject newCoin = coinPool.GetPooledObject();

			float coinXposition = Random.Range (1,7);

			Vector3 coinPosition = new Vector3(coinXposition, 1f, 0f);

			newCoin.transform.position = transform.position + coinPosition;
			newCoin.transform.rotation = transform.rotation;
			newCoin.SetActive(true);
		}
	}
}




