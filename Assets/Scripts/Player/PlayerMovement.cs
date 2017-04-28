using Assets.Scripts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private bool KEY_MOVE_UP() { return (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)); }
	private bool KEY_MOVE_LEFT() { return (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)); }
	private bool KEY_MOVE_DOWN() { return (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)); }
	private bool KEY_MOVE_RIGHT() { return (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)); }

	private const float ACCELERATION_SCALE = 1.5f;

	private Vector3 _acceleration = Vector2.zero;
	private Vector3 _velocity = Vector2.zero;
	private GameObject _player = null;
	private Vector3 _spriteLeft = new Vector3(1,1,1);
	private Vector3 _spriteRight = new Vector3(-1, 1, 1);
	private Transform _playerTransform;

	private SpriteRenderer _spriteRenderer = null;

	private void Awake() {
		_player = GameObject.FindWithTag(Constants.Tags.Player);
		_playerTransform = _player.transform;
		_velocity = Vector2.zero;
		_spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		UpdatePlayerMovement();
	}

	private void UpdatePlayerMovement() {
		if(KEY_MOVE_UP()) {
			_acceleration += GetAccelerationScaled(Vector3.up);
		}
		if(KEY_MOVE_DOWN()) {
			_acceleration += GetAccelerationScaled(Vector3.down);
		}
		if(KEY_MOVE_LEFT()) {
			_acceleration += GetAccelerationScaled(Vector3.left);
			_playerTransform.localScale = _spriteLeft;
		}
		if(KEY_MOVE_RIGHT()) {
			_acceleration += GetAccelerationScaled(Vector3.right);
			_playerTransform.localScale = _spriteRight;
		}

		_velocity += _acceleration;
		_playerTransform.position += _velocity;

		_acceleration = Vector3.Slerp(_acceleration, Vector3.zero, 0.5f);
		_velocity = Vector3.Slerp(_velocity, Vector3.zero, 0.5f);

		ClampPlayerPosition();

		AdjustZPosition();
	}

	private Vector3 GetAccelerationScaled(Vector3 acceleration) {
		return (acceleration * ACCELERATION_SCALE * Time.deltaTime);
	}

	private void ClampPlayerPosition() {
		const float xBound = 9.0f;
		const float yBound = 5.5f;
		Vector3 playerPos = _playerTransform.position;
		playerPos.x = Mathf.Clamp(playerPos.x, -xBound, xBound);
		playerPos.y = Mathf.Clamp(playerPos.y, -yBound, yBound);
		_playerTransform.position = playerPos;
	}

	// Special hacky function to position Player in front of or behind the HomeBase...
	private void AdjustZPosition() {
		Vector3 playerPos = _playerTransform.position;
		// This is a magic number for the bottom of the HomeBase sprites...
		_spriteRenderer.sortingOrder = (playerPos.y < -0.33f) ? 2 : 0;
	}
}
