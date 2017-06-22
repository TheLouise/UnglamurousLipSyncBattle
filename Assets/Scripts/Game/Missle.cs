using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 point2Target;

	private float speed = 7;
	private float rotatingSpeed = 700;
	private float timeToDestruct = 5;
	private float timeCounter = 0;
	private int index;

	public Rigidbody2D target;

	public void SetIndex(int _index) {
		this.index = _index;

		if (this.index == 1) 
			target = GameObject.Find ("enemy").GetComponent<Rigidbody2D> ();

		if (this.index == 2)
			target = GameObject.Find ("player").GetComponent<Rigidbody2D> ();

		rb = GetComponent<Rigidbody2D> ();

		gameObject.SetActive (true);
	}

	void Update() {
		timeCounter += Time.deltaTime;

		if (timeCounter >= timeToDestruct)
			gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
			point2Target.Normalize ();

			float value = Vector3.Cross (point2Target, transform.right).z;

			if (rb != null) {
				rb.angularVelocity = rotatingSpeed * value;
				rb.velocity = transform.right * speed;
			}
		}
	}
}
