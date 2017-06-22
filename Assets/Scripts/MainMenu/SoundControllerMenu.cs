using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerMenu : MonoBehaviour {

	public LoadSceneByIndex indexController;
	private AudioSource soundtrack;

	// Use this for initialization
	void Start () {
		soundtrack = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (indexController.isPlaying == true) {
			soundtrack.pitch *= 0.99f;
			if (soundtrack.pitch < 0.1f)
				soundtrack.mute = true;
		}
	}
}
