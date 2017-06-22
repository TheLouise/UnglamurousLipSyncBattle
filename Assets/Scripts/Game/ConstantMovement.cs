using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour {

	private GameObject body;

	private float timeCounter = 0;

	public Vector3 movement;
	public GameObject obj;

	public float timeToDestruct;
	public string mytag;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (movement * Time.deltaTime);

		timeCounter += Time.deltaTime;

		if (timeCounter >= timeToDestruct)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == mytag) {
			Destroy (obj);
		}
	}

	public void InverteTiro () {
		movement.x = -movement.x;
	}
}
