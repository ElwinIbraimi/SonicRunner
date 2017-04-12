using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount;

	List<GameObject> pooledObjects;


	// Use this for initialization
	void Start () 
	{
		// zeg dat de variabele pooledObjects
		pooledObjects = new List<GameObject> ();
		// voor elke i dat lager is dan de aantal objecten
		for (int i = 0; i < pooledAmount; i++) 
		{
			// maak een nieuw object aan
			GameObject obj = (GameObject)Instantiate (pooledObject);
			// zet het object op false
			obj.SetActive (false);
			// voeg de objecten toe aan de lijst
			pooledObjects.Add (obj);
		}
	}
	
	// haal het gepoolde object op
	public GameObject GetPooledObject () 
	{
		// als i kleiner is dan het aantal gepoolde objecten
		for (int i =0; i < pooledObjects.Count; i++) 
		{
			// en als de gepoolde objective niet active staan in de hierarchy
			if (!pooledObjects[i].activeInHierarchy)
			{
				// 
				return pooledObjects[i];
			}
		}
		// zet alle objecten op de aangegeven plek
		GameObject obj = (GameObject)Instantiate (pooledObject);
		obj.SetActive (false);
		pooledObjects.Add (obj);

		return obj;
	}
}
