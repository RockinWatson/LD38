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

	[SerializeField]
	private bool _timedAttack = true;
	[SerializeField]
	private float _attackSpeed = 0.25f;
	private float _attackTimer = 0.0f;

	private EnemyMovement _movement = null;

	private float _targetUpdateThrottleTime = 0.25f;
	private float _targetUpdateTimer = 0.0f;

	private void Awake() {
		_movement = this.GetComponent<EnemyMovement>();
	}

	private void Start() {
		_attackTimer = 0.0f;
		FindAndSetTarget();
	}

	// Update is called once per frame
	private void Update () {
		_targetUpdateTimer += Time.deltaTime;
		if(_targetUpdateTimer >= _targetUpdateThrottleTime) {
			FindAndSetTarget();
		}

		if(_timedAttack) {
			_attackTimer += Time.deltaTime;
			if(CanAttack()) {
				AttackSomething();
			}
		}
	}

	private void FindAndSetTarget() {
		GameObject target = FindTarget();
		_movement.SetTarget(target);
		_targetUpdateTimer = 0.0f;
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

	private bool CanAttack() {
		return (!_timedAttack || (_attackTimer >= _attackSpeed));
	}

	public bool AttackObject(GameObject other) {
		bool attacked = false;
		if(CanAttack() && IsTargetEnemy(other)) {
			if(other.tag == Constants.Tags.Mushmen) {
				MushmanBase mushman = other.GetComponent<MushmanBase>();
				mushman.Damage(_damage);
				attacked = true;
			}
			else if (other.tag == Constants.Tags.HomeBase)
			{
				HomeBase homeBase = other.GetComponent<HomeBase>();
				homeBase.Damage(_damage);
				attacked = true;
			}
			else if (other.tag == Constants.Tags.Player)
			{
				Player player = other.GetComponent<Player>();
				player.Damage(_damage);
				attacked = true;
			}
			if(attacked) {
				_attackTimer = 0.0f;
			}
		}
		return attacked;
	}

	private void AttackSomething() {
		// Find nearby something to attack...
		GameObject target = null;
    Collider2D[] colliders = new Collider2D[9];
    ContactFilter2D filter = new ContactFilter2D();
    filter.NoFilter();
    int count = Physics2D.OverlapCollider(this.GetComponent<Collider2D>(), filter, colliders);
    if(count > 0) {
      foreach(Collider2D collider in colliders) {
				if(collider) {
					GameObject other = collider.gameObject;
					if(IsTargetEnemy(other)) {
						target = other;
						break;
					}
				}
      }
    }

		if(target != null) {
			AttackObject(target);
		}
	}

	private bool IsTargetEnemy(GameObject other) {
		return(
		other.tag == Constants.Tags.Mushmen ||
		other.tag == Constants.Tags.HomeBase ||
		other.tag == Constants.Tags.Player
		);
	}
}
