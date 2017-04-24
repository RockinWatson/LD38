using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : Enemy {

	private Rigidbody2D _rigidBody = null;

	protected override void Awake() {
		base.Awake();
		_rigidBody = this.GetComponent<Rigidbody2D>();
	}

	override protected float GetDamageScale() {
		float scale = _rigidBody.velocity.sqrMagnitude;
		return Mathf.Max(1.0f, scale);
	}
}
