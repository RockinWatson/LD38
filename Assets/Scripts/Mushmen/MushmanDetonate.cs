using Assets.Scripts;
using UnityEngine;

public class MushmanDetonate : MonoBehaviour {

	[SerializeField]
	private float _damageRadius = 3.0f;

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == Constants.Tags.Enemy) {
			Detonate();
		}
	}

	public void Detonate() {
		MushmanBase mushman = this.GetComponent<MushmanBase>();

		// Find all Enemies within its radius.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, _damageRadius);
		foreach(Collider2D collider in colliders) {
			if(collider.tag == Constants.Tags.Enemy) {
				Enemy enemy = collider.GetComponent<Enemy>();
				mushman.AttackTarget(enemy);
			}
		}

		mushman.Die();
	}
}
