using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class LoadSceneOnKeyDowns : MonoBehaviour {

	[SerializeField]
	private Constants.Scenes.SceneType _scene;

	[SerializeField]
	private List<KeyCode> _keyDowns = null;

	// Update is called once per frame
	void Update () {
		foreach(KeyCode key in _keyDowns) {
			if(Input.GetKeyDown(key)) {
				LoadScene();
			}
		}
	}

	private void LoadScene() {
		string sceneName = Constants.Scenes.GetSceneName(_scene);
		SceneManager.LoadScene(sceneName);
	}
}
