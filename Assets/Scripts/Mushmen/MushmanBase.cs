using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MushmanBase : MonoBehaviour {

	[SerializeField]
	private float _health = 50;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	private void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
