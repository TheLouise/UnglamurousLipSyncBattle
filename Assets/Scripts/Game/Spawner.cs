using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private float cooldownTimer = 0;

	public GameObject prefab;
	public TimeController timer;
	public Transform start;
	public Transform end;

	public int startTimer;
	public float cooldown;
	public float timeToDestruct;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		cooldownTimer += Time.deltaTime;

		if (cooldownTimer >= cooldown && timer.timer < startTimer)
			Spawn ();
	}

	void Spawn(){
		Vector3 position = new Vector3 ();

		position.x = Random.Range (start.position.x, end.position.x);
		position.y = Random.Range (start.position.y, end.position.y);
		position.z = Random.Range (start.position.z, end.position.z);

		Instantiate (prefab, position, Quaternion.identity);

		cooldownTimer = 0;
	}
}
