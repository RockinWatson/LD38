using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour {

	static private FXManager _singleton = null;
	static public FXManager Get() { return _singleton; }

	[SerializeField]
	private GameObject _kablooeyPrefab = null;

	void Awake() {
		_singleton = this;
	}

	public void SpawnKablooey(Vector3 pos) {
		GameObject kablooey = (GameObject)Instantiate(_kablooeyPrefab);
		kablooey.transform.position = pos;
	}
}
