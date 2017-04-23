using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanRocket : MushmanSeeker {

	[SerializeField]
	private float _damageRadius = 5.0f;

	override protected void AttackTarget(Enemy enemy) {
		base.AttackTarget(enemy);
  }
}
