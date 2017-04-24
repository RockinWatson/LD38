using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private float _health = 50.0f;

	public void Damage(float amount) {
		_health -= amount;
		if(_health <= 0.0f) {
			Die();
		}
	}

	private void Die() {
		FXManager.Get().SpawnKablooey(this.transform.position);
		Destroy(this.gameObject);
	}
}
