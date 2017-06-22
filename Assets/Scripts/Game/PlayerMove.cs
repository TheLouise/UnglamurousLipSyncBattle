using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArcadePUCCampinas;

public class PlayerMove : MonoBehaviour {

	public int jogador;

	private Rigidbody2D body;
	private Rigidbody2D enemy;
	private Animator anim;

	private bool canJump = false;

	private float walkforce = 500f;
	private float jumpforce = 350f;

	public TimeController controler;

	public bool caiu = false;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		if (jogador == 0)
			enemy = GameObject.Find ("enemy").GetComponent<Rigidbody2D> ();
		if (jogador == 1)
			enemy = GameObject.Find ("player").GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* if (Input.GetKeyDown (KeyCode.W) &&  canJump == true)
			body.AddForce (new Vector2 (0, jumpforce)); */

		if(InputArcade.Apertou(jogador, EControle.VERDE) == true && canJump == true)
			body.AddForce(new Vector2(0, jumpforce));

		//float direction = Input.GetAxis ("HorizontalSetas");
		float direction = InputArcade.Eixo (jogador, EEixo.HORIZONTAL);
		body.velocity = new Vector2 (walkforce * direction * Time.deltaTime, body.velocity.y);

		if ((body.velocity.x > 0.03f) || (body.velocity.x < -0.03f)) {
			anim.SetInteger ("State", 1);
		} else {
			anim.SetInteger ("State", 0);
		}

		if (jogador == 0) {
			if (body.position.x > enemy.position.x)
				transform.eulerAngles = new Vector3 (0, 180, 0);
			else
				transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		if (jogador == 1) {
			if (body.position.x < enemy.position.x)
				transform.eulerAngles = new Vector3 (0, 180, 0);
			else
				transform.eulerAngles = new Vector3 (0, 0, 0);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "ground")
			canJump = true;

		if (col.gameObject.tag == "hole") {
			controler.isRunning = false;
			caiu = true;
		}

		if (col.gameObject.tag == tag) {
			controler.isRunning = true;
			caiu = true;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "ground")
			canJump = false;
	}
}
