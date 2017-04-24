using UnityEngine;

public class MushmanRocket : MushmanBase {
	[SerializeField]
	private float _lifeTime = 3.0f;
	private float _lifeTimer = 0.0f;

	private Rigidbody2D _rigidBody = null;
	private const float MIN_SPEED_THRESHOLD_SQR = 1.0f;

	private void Awake() {
		_lifeTimer = 0.0f;

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
}
