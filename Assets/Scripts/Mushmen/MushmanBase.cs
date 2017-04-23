using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;

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

	public void Die() {
		FXManager.Get().SpawnKablooey(this.transform.position);
		Destroy(this.gameObject);
	}

	public virtual void AttackTarget(Enemy enemy) {
		float amount = enemy.Damage(GetDamage());

		// Add transferred resources to home base.
		HomeBase homeBase = GameObject.FindGameObjectWithTag(Constants.Tags.HomeBase).GetComponent<HomeBase>();
		homeBase.AddResource(amount);
	}
}
