using UnityEngine;

public class Olive : MonoBehaviour {

	[SerializeField]
	private float _rotateSpeed = 1.0f;

	private Rigidbody2D _rigidBody = null;

	private void Awake() {
		_rigidBody = this.GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		float speed = _rigidBody.velocity.sqrMagnitude;
		float direction = GetDirection(_rigidBody.velocity);
		this.transform.RotateAround(this.transform.position, Vector3.forward, _rotateSpeed * speed * Time.deltaTime * direction);
	}

	private float GetDirection(Vector3 velocity) {
		float dotLeft = Vector3.Dot(velocity, Vector3.left);
		float dotRight = Vector3.Dot(velocity, Vector3.right);
		return (dotLeft > dotRight) ? 1.0f : -1.0f;
	}
}
