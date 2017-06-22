using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifebarController : MonoBehaviour {

	public PlayerHealth currentHealth;
	public Image lifeBar;

	// Update is called once per frame
	void Update () {
		lifeBar.fillAmount = Conversor ((float)currentHealth.health);
		
	}

	private float Conversor(float _currentHealth) {

		return _currentHealth / 100;
	}
}
