using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	public TimeController timer;
	private AudioSource soundtrack;

	// Use this for initialization
	void Start () {
		soundtrack = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timer.isRunning == false) {
			soundtrack.pitch *= 0.99f;
			if (soundtrack.pitch < 0.1f) {
				soundtrack.mute = true;
			}
		}
	}
}
