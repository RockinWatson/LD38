using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanWalker : MushmanBase {

  [SerializeField]
  private float _attackSpeed = 0.5f;
  private float _attackTimer = 0.0f;

  private bool _isAttacking = false;


  private void Update() {
    if(_isAttacking) {
      _attackTimer -= Time.deltaTime;
      if(_attackTimer <= 0.0f) {
        FindAndAttackEnemy();
      }
    }
  }

  private void FindAndAttackEnemy() {
    // Find all Enemies within its radius.
    bool foundEnemy = false;
    Collider2D[] colliders = null;
    ContactFilter2D filter = new ContactFilter2D();
    filter.NoFilter();
    Physics2D.OverlapCollider(this.GetComponent<Collider2D>(), filter, colliders);
    if(colliders != null && colliders.Length > 0) {
      foreach(Collider2D collider in colliders) {
  			if(collider.tag == "Enemy") {
          foundEnemy = true;
  				Enemy enemy = collider.GetComponent<Enemy>();
  				MushmanBase mushman = this.GetComponent<MushmanBase>();
  				mushman.AttackTarget(enemy);
          break;
        }
      }
    }

    if(!foundEnemy) {
      _isAttacking = false;
    }
  }

  override public void AttackTarget(Enemy enemy) {
    _attackTimer = _attackSpeed;
    base.AttackTarget(enemy);
  }

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			AttackTarget(enemy);
		}
	}
}
