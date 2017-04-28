using UnityEngine;

using Assets.Scripts;

public class MushmanRocket : MushmanBase {

	[SerializeField]
	private float _speed = 1.0f;

	[SerializeField]
	private float _speedRamp = 0.0f;

	[SerializeField]
	private float _rotateSpeed = 3.0f;

	[SerializeField]
	private float _rotateRocketSpeed = 4.0f;

	[SerializeField]
	private float _lifeTime = 3.0f;
	private float _lifeTimer = 0.0f;

	private Rigidbody2D _rigidBody = null;
	private const float MIN_SPEED_THRESHOLD_SQR = 1.0f;

	private GameObject _target = null;

	private void Awake() {
		_lifeTimer = 0.0f;

		_target = null;

		_rigidBody = this.GetComponent<Rigidbody2D>();
	}

	private void Start() {
		this.transform.Rotate(Vector3.forward * 90.0f);
	}

	private void Update() {
		bool detonate = false;

		_lifeTimer += Time.deltaTime;
		if(_lifeTimer > _lifeTime) {
			detonate = true;
		}

		if(_rigidBody.velocity.sqrMagnitude < MIN_SPEED_THRESHOLD_SQR) {
			detonate = true;
		}

		if(detonate) {
			MushmanDetonate detonater = this.GetComponent<MushmanDetonate>();
			detonater.Detonate();
		}
	}

	private void FixedUpdate() {
		MoveToTarget();
	}

	private void FindTarget() {
		float bestDistance = float.MaxValue;
		GameObject newTarget = null;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.Tags.Enemy);
		foreach(GameObject enemy in enemies) {
			//DebugDrawTarget(enemy);
			float distance = (enemy.transform.position - this.transform.position).sqrMagnitude;
			if(distance < bestDistance) {
				newTarget = enemy;
				bestDistance = distance;
			}
		}
		if(newTarget) {
			_target = newTarget;
		}
	}

	private void MoveToTarget() {
		if(!_target) {
			FindTarget();
		}
		if(_target) {
			Vector3 dirToTarget = (_target.transform.position - this.transform.position).normalized;

			_rigidBody.velocity = (dirToTarget * Time.fixedDeltaTime * _speed);

			_speed += (_speedRamp * Time.fixedDeltaTime);

			// Rotate to target...
			Vector2 rocketDir = (this.transform.right * Time.fixedDeltaTime * _rotateRocketSpeed);
			_rigidBody.velocity += rocketDir;
			float angle = Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg;
		 	Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		 	this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.fixedDeltaTime * _rotateSpeed);
		}
	}
}
