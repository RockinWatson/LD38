using Assets.Scripts;
using UnityEngine;

public class MushmanSeeker : MonoBehaviour {

	[SerializeField]
	private float _speed = 1.0f;

	[SerializeField]
	private float _speedRamp = 0.0f;

	[SerializeField]
	private bool _rotateToTarget = false;

	[SerializeField]
	private float _rotateSpeed = 3.0f;

	[SerializeField]
	private float _rotateRocketSpeed = 4.0f;

	private GameObject _target = null;

	private Rigidbody2D rigidBody = null;

	private void Awake() {
		_target = null;
		rigidBody = this.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	// private void Update () {
	// 	_speed += (_speedRamp * Time.deltaTime);
	//
	// 	MoveToTarget();
	// }

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
			//DebugDrawTarget(_target);

			Vector3 dirToTarget = (_target.transform.position - this.transform.position).normalized;
			//Debug.DrawRay(this.transform.position, dirToTarget, Color.magenta);
			//this.transform.position += (dirToTarget * Time.deltaTime * _speed);

			rigidBody.velocity = (dirToTarget * Time.fixedDeltaTime * _speed);

			_speed += (_speedRamp * Time.fixedDeltaTime);

			if(_rotateToTarget) {
				Vector2 rocketDir = (this.transform.right * Time.fixedDeltaTime * _rotateRocketSpeed);
				rigidBody.velocity += rocketDir;
				//this.transform.position += (this.transform.right * Time.deltaTime * _rotateRocketSpeed);

				float angle = Mathf.Atan2(dirToTarget.y, dirToTarget.x) * Mathf.Rad2Deg;
			 	Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			 	this.transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.fixedDeltaTime * _rotateSpeed);
			}
		}
	}

	private void DebugDrawTarget(GameObject go) {
		Debug.DrawRay(go.transform.position, Vector3.up, Color.red);
		Debug.DrawRay(go.transform.position, Vector3.left, Color.green);
	}
}
