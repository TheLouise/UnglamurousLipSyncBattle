using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArcadePUCCampinas;

public class PlayerShoot : MonoBehaviour {

	public int jogador;

	private Animator anim;
	private GameObject missleObject;

	private bool upadoSpeed = false;
	private bool upadoMissle = false;

	private float pwrSpeed = 0.45f;
	private float pwrSpeedDuration = 3;
	private float cooldownTimer = 0;

	public GameObject tiro;
	public GameObject missle;
	public GameObject missleIndicator;
	public Transform spawn;
	public Vector3 movement;
	//public KeyCode shootCode;
	//public KeyCode pwrMissleCode;

	public int playerIndex;

	public string pwrSpeedTag;
	public string pwrMissleTag;

	public float cooldown;
	private float timeToDestruct = 3;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		missleIndicator.SetActive (false);
		missle.SetActive (true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		cooldownTimer += Time.deltaTime;
		timeToDestruct += Time.deltaTime;

		//if (Input.GetKeyDown (shootCode) && cooldownTimer >= cooldown) {
		if(InputArcade.Apertou(jogador, EControle.VERMELHO) == true && cooldownTimer >= cooldown)
			Atirar ();
		 else 
			anim.SetBool ("Atirando", false);

		if(InputArcade.Apertou(jogador, EControle.PRETO) == true && upadoMissle == true)
			ActivateMissleUp();
	}

	void OnCollisionEnter2D(Collision2D col) {
		
		//POWER UP 1 - DIMINUIR O COOLDOWN DOS TIROS
		//Colocar OnDestroy() no invoke
		if (col.gameObject.tag == pwrSpeedTag) {
			if (upadoSpeed == false) {
				ActivateSpeedUp ();
				Debug.Log ("Upado Speed: " + upadoSpeed);
				Invoke ("DesactivateSpeedUp", pwrSpeedDuration);
				Destroy (col.gameObject);
			} else
				Destroy (col.gameObject);
		}

		//POWERUP 02 - MISSIL TELEGUIADO
		if (col.gameObject.tag == pwrMissleTag) {
			upadoMissle = true;
			Destroy (col.gameObject);
			missleIndicator.SetActive (true);
			Debug.Log ("Upado Missle: " + upadoMissle);
		}
	}

	void Atirar() {
		anim.SetBool ("Atirando", true);

		GameObject tiroObject = Instantiate (tiro, spawn.position, Quaternion.identity);
		ConstantMovement cm = tiroObject.GetComponent<ConstantMovement> ();

		if (transform.eulerAngles.y == 180)
			cm.InverteTiro ();

		cooldownTimer = 0;
		tiro.transform.Translate (movement * Time.deltaTime);
	}

	//POWERUP 01 - DIMINUIR COOLDOWN DOS TIROS
	void ActivateSpeedUp() {
		upadoSpeed = true;
		cooldown = cooldown - pwrSpeed;
	}

	void DesactivateSpeedUp() {
		cooldown = cooldown + pwrSpeed;
		upadoSpeed = false;
	}

	//POWERUP 02 - MISSIL TELEGUIADO
	void ActivateMissleUp() {
		//if (Input.GetKeyDown (pwrMissleCode) && upadoMissle == true) {
			anim.SetInteger ("State", 3);

			missleObject = Instantiate (missle, spawn.position, Quaternion.identity);
			missleObject.GetComponent<Missle> ().SetIndex (playerIndex);

		if (timeToDestruct == 3)
			Destroy (missleObject);
			
			Invoke ("DestroyMissle", 3);

			missleIndicator.SetActive (false);
			Debug.Log ("Upado Missle: " + upadoMissle);
			upadoMissle = false;
	}

	void DestroyMissle() {
		//missle.SetActive(false);
		Destroy(missleObject);
	}
}
