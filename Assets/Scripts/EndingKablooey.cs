using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class EndingKablooey : MonoBehaviour {

	[SerializeField]
	private List<GameObject> _prefabs = null;

	[SerializeField]
	private float _totalTime = 5.0f;

	[SerializeField]
	private int _numObjects = 10;

	[SerializeField]
	Constants.Scenes.SceneType _scene;

	private void Awake() {
	}

	private void Start() {
		// Generate all the sprites...
		for(int i=0; i < _numObjects; ++i) {
			GameObject prefab = GetRandomPrefab();
			GameObject star = (GameObject)Instantiate(prefab);
			Vector3 pos = this.transform.position;
			pos.z = -4.0f;
			star.transform.position = pos;
			Rigidbody2D rigidBody = star.AddComponent<Rigidbody2D>();
			rigidBody.gravityScale = 0.0f;
			Vector3 dir = GetRandomDir();
			star.transform.eulerAngles = dir;
			rigidBody.velocity = GetRandomDir() * GetRandomSpeed();
		}
	}

	private void Update() {
		//
		_totalTime -= Time.deltaTime;
		if(_totalTime < 0.0f) {
			string sceneName = Constants.Scenes.GetSceneName(_scene);
			SceneManager.LoadScene(sceneName);
		}
	}

	private GameObject GetRandomPrefab() {
		return _prefabs[Random.Range(0, _prefabs.Count-1)];
	}

	private float GetRandomSpeed() {
		return Random.Range(1.0f, 5.0f);
	}

	private Vector3 GetRandomDir() {
		return new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(0.0f, 1.0f), 0.0f);
	}
}
