using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanWalker : MushmanBase {

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			AttackTarget(enemy);
		}
	}
}
