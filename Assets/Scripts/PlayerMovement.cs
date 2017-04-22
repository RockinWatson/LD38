using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private const KeyCode KEY_MOVE_UP = KeyCode.W;
	private const KeyCode KEY_MOVE_LEFT = KeyCode.A;
	private const KeyCode KEY_MOVE_DOWN = KeyCode.S;
	private const KeyCode KEY_MOVE_RIGHT = KeyCode.D;

	private const float ACCELERATION_SCALE = 1.5f;

	private Vector3 _acceleration = Vector2.zero;
	private Vector3 _velocity = Vector2.zero;
	private GameObject _player = null;

	private void Awake() {
		_velocity = Vector2.zero;
	}

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		UpdatePlayerMovement();
	}

	private void UpdatePlayerMovement() {
		if(Input.GetKey(KEY_MOVE_UP)) {
			_acceleration += GetAccelerationScaled(Vector3.up);
		}
		if(Input.GetKey(KEY_MOVE_DOWN)) {
			_acceleration += GetAccelerationScaled(Vector3.down);
		}
		if(Input.GetKey(KEY_MOVE_LEFT)) {
			_acceleration += GetAccelerationScaled(Vector3.left);
		}
		if(Input.GetKey(KEY_MOVE_RIGHT)) {
				_acceleration += GetAccelerationScaled(Vector3.right);
		}

		_velocity += _acceleration;
		_player.transform.position += _velocity;

		_acceleration = Vector3.Slerp(_acceleration, Vector3.zero, 0.5f);
		_velocity = Vector3.Slerp(_velocity, Vector3.zero, 0.5f);
	}

	private Vector3 GetAccelerationScaled(Vector3 acceleration) {
		return (acceleration * ACCELERATION_SCALE * Time.deltaTime);
	}
}
