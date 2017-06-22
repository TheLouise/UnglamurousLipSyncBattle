using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	private int danoTiro = 5;
	private int danoMissil = 30;

	public int bonus;
	public int health = 100;
	public string tirotag;
	public string bonusTag;
	public string missleTag;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == tirotag) {
			health -= danoTiro;
		}

		if (col.gameObject.tag == bonusTag) {
			health += bonus;
			Destroy (col.gameObject);
		}

		if (col.gameObject.tag == missleTag) {
			health -= danoMissil;
			Destroy (col.gameObject);
		}
	}
}
