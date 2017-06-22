using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByIndex : MonoBehaviour {

	private AudioSource song;

	public bool isPlaying;
	public int sceneIndex; 

	void Start() {
		song = GetComponent<AudioSource> ();
		isPlaying = false;
	}

	public void OnClick() {
		isPlaying = true;
		song.PlayDelayed (3);
		Invoke ("LoadScene", 10);
	}

	public void LoadScene () {
		SceneManager.LoadScene (sceneIndex);
	}
}
