using Assets.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

  public GameObject _target;
  public int MoveSpeed;

  private bool _isColliding;
  private Transform _myTransform;
  private readonly Vector3 _left = new Vector3(-1,1,1);
  private readonly Vector3 _right = new Vector3(1, 1, 1);

  private Rigidbody2D _rigidBody = null;

  void Awake()
  {
    _myTransform = transform;
    _rigidBody = this.GetComponent<Rigidbody2D>();
  }

  public void SetTarget(GameObject target) {
    _target = target;
  }

  void FixedUpdate() {
    if (_target != null)
    {
      //Movin to the target
      _rigidBody.velocity = ((_target.transform.position - _myTransform.position).normalized * MoveSpeed * Time.fixedDeltaTime);
    }
  }

  private void Update() {
    UpdateOrientation();
  }

  private void UpdateOrientation() {
    _myTransform.localScale = (_myTransform.position.x > 0) ? _left : _right;
  }
}
