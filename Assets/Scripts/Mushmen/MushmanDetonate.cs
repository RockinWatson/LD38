using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanDetonate : MonoBehaviour {

	[SerializeField]
	private float _damageRadius = 3.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			//Enemy enemy = other.gameObject.GetComponent<Enemy>();
			Detonate();
		}
	}

	private void Detonate() {
		// Find all Enemies within its radius.
		bool foundEnemy = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, _damageRadius);
		if(colliders != null && colliders.Length > 0) {
			Debug.Log("We Found some Colliders");
		}
		foreach(Collider2D collider in colliders) {
			if(collider.tag == "Enemy") {
				foundEnemy = true;
				Enemy enemy = collider.GetComponent<Enemy>();
				MushmanBase mushman = this.GetComponent<MushmanBase>();
				mushman.AttackTarget(enemy);
			}
		}

		if(foundEnemy) {
			Destroy(this.gameObject);
		}
	}
}
