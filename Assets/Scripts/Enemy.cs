using UnityEngine;

using Assets.Scripts;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private float _health = 50;

	[SerializeField]
	private float _damage = 30;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public float Damage(float amount) {
		_health -= amount;
		if(_health <= 0.0f) {
			Die();

			amount += _health;
		}

		return amount;
	}

	private void Die() {
		FXManager.Get().SpawnKablooey(this.transform.position);
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D other) {
		//@TODO: Enter into Attack Mode with Timed Attack.
		if(other.gameObject.tag == Constants.Tags.Mushmen) {
			MushmanBase mushman = other.gameObject.GetComponent<MushmanBase>();
			mushman.Damage(_damage);
		}
		else if (other.gameObject.tag == Constants.Tags.HomeBase)
		{
			HomeBase homeBase = other.gameObject.GetComponent<HomeBase>();
			homeBase.Damage(_damage);
		}
	}
}
