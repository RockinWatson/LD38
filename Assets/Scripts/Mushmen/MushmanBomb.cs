using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanBomb : MushmanBase {

	[SerializeField]
	private float _damageRadius = 10.0f;

	override protected void AttackTarget(Enemy enemy) {
		Detonate();
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
				base.AttackTarget(enemy);
			}
		}

		if(foundEnemy) {
			Destroy(this.gameObject);
		}
	}
}
