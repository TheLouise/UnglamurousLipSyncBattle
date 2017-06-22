using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public int sceneIndex;

	public void RestartOnClick() {
		SceneManager.LoadScene (sceneIndex);
	}
}
