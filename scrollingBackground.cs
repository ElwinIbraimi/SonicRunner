using UnityEngine;
using System.Collections;

public class scrollingBackground : MonoBehaviour {

	public float backgroundSize;
	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;


	private void Start(){
		cameraTransform = Camera.main.transform;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
		

	private void ScrollRight(){
		int lastLeft = leftIndex;
		layers [leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
		
	}

	private void Update(){

		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone))
			ScrollRight ();

	}
}
