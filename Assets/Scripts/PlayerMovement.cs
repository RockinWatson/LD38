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

    private void Awake() {
		_velocity = Vector2.zero;
        _playerTransform = transform;
	}

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag(Constants.Tags.Player);
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
		_player.transform.position += _velocity;

		_acceleration = Vector3.Slerp(_acceleration, Vector3.zero, 0.5f);
		_velocity = Vector3.Slerp(_velocity, Vector3.zero, 0.5f);
	}

	private Vector3 GetAccelerationScaled(Vector3 acceleration) {
		return (acceleration * ACCELERATION_SCALE * Time.deltaTime);
	}
}
