using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private float _health = 50;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public void Damage(float amount) {
		_health -= amount;
		if(_health <= 0.0f) {
			Die();
		}
	}

	private void Die() {
		Destroy(this.gameObject);
	}
}
