using System.Collections;
using UnityEngine;

using Assets.Scripts;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private float _health = 50;

	[SerializeField]
	private float _damage = 30;

	[SerializeField]
	private bool _ignoresMushmen = false;

	[SerializeField]
	private float _alertRadius = 3.0f;

	private EnemyMovement _movement = null;

	private float _targetUpdateThrottleTime = 0.25f;
	private float _targetUpdateTimer = 0.0f;

	private void Awake() {
		_movement = this.GetComponent<EnemyMovement>();
	}

	private void Start() {
		FindAndSetTarget();
	}

	// Update is called once per frame
	private void Update () {
		_targetUpdateTimer += Time.deltaTime;
		if(_targetUpdateTimer > _targetUpdateThrottleTime) {
			FindAndSetTarget();
			_targetUpdateTimer = 0.0f;
		}
	}

	private void FindAndSetTarget() {
		GameObject target = FindTarget();
		_movement.SetTarget(target);
	}

	private GameObject FindTarget() {
		GameObject target = null;

		// Try to find nearby Mushman (including Player).
		if(!_ignoresMushmen) {
			Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, _alertRadius);
			float bestDistance = float.MaxValue;
			foreach(Collider2D collider in colliders) {
				if(collider.tag == Constants.Tags.Mushmen || collider.tag == Constants.Tags.Player) {
					float distanceSqr = (collider.transform.position - this.transform.position).sqrMagnitude;
					if(distanceSqr < bestDistance) {
						bestDistance = distanceSqr;
						target = collider.gameObject;
					}
				}
			}
		}

		// Fallback on the HomeBase.
		if(!target) {
			target = HomeBase.Get().gameObject;
		}

		return target;
	}

    public void EnemyDeathAudio()
    {
        var death_audio = GameObject.Find("AudioController");
        death_audio.GetComponent<AudioController>().enemyDeathAudio();
    }

    public float Damage(float amount) {
		_health -= amount;
		if(_health <= 0.0f) {
            EnemyDeathAudio();
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
		else if (other.gameObject.tag == Constants.Tags.Player)
		{
			Player player = other.gameObject.GetComponent<Player>();
			player.Damage(_damage);
		}
	}
}
