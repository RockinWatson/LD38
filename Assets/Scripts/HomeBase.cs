using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour {

	const float MAX_RESOURCE = 100.0f;
	
	private float _resource = MAX_RESOURCE;

	public bool HasEnoughResource(float amount) {
		return (amount <= _resource);
	}

	public void AddResource(float amount) {
		_resource += amount;
	}

	public void Damage(float amount) {
		_resource -= amount;

		// Death Scenario:
		if(_resource <= 0.0f) {
			Die();
		}
	}

	private void Awake() {
		_resource = 0.0f;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void Die() {
		//@TODO: Die Mofucka.
	}
}
