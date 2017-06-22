using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	private float endTimer;
	private bool endLifePlayer;
	private bool endLifeEnemy;

	public Text timerTxt;

	public PlayerHealth healthPlayer;
	public PlayerHealth healthEnemy;

	public GameObject endPanel;
	public GameObject playerWins;
	public GameObject enemyWins; 

	public PlayerMove p1Move;
	public PlayerMove p2Move;

	public float timer;
	public bool isRunning;

	// Use this for initialization
	void Start () {
		float oldTimer = timer;

		isRunning = true;
		endLifePlayer = false;
		endLifeEnemy = false;
		Time.timeScale = 1;

		endPanel.SetActive (false);
		enemyWins.SetActive (false);
		playerWins.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

		if (isRunning) {
			timer -= Time.deltaTime;
			timerTxt.text =  Mathf.RoundToInt (timer).ToString ();
		}

		if (healthPlayer.health <= 0 || healthEnemy.health <= 0 || isRunning == false) {
			isRunning = false;
			Time.timeScale = 0;
			endTimer += Time.unscaledDeltaTime;

			if (endTimer > 2.5) {
				if (endLifePlayer == true) {
					endPanel.SetActive (true);
					enemyWins.SetActive (true);
				}
				if (endLifeEnemy == true) {
					endPanel.SetActive (true);
					playerWins.SetActive (true);
				}

				if (p1Move.caiu == true) {
					endPanel.SetActive (true);
					enemyWins.SetActive (true);
				}
				if (p2Move.caiu == true) {
					endPanel.SetActive (true);
					playerWins.SetActive (true);
				}
			}

			if (healthPlayer.health <= 0)
				endLifePlayer = true;

			if (healthEnemy.health <= 0)
				endLifeEnemy = true;
		}
			
		if (timer <= 0) {
			isRunning = false;
			Time.timeScale = 0;

			if (healthPlayer.health > healthEnemy.health) {
				endLifeEnemy = true;
			}

			if (healthPlayer.health < healthEnemy.health) {
				endLifePlayer = true;
			}
		}
			
	}
}
