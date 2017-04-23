using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MushmanBase : MonoBehaviour {

	[SerializeField]
	private float _health = 50.0f;

	[SerializeField]
	private float _damage = 10.0f;

	protected float GetDamage() { return _damage; }

	private void OnBecameInvisible() {
		Destroy(this.gameObject);
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

	protected virtual void AttackTarget(Enemy enemy) {
		enemy.Damage(GetDamage());
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			AttackTarget(enemy);
		}
	}
}
