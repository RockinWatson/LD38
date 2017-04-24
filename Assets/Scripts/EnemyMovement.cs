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
    if (_isColliding)
    {
      _rigidBody.velocity = Vector2.zero;
      //MoveSpeed = 0;
    }
    else
    {
      if (_target != null)
      {
        //Movin to the target
        _rigidBody.velocity = ((_target.transform.position - _myTransform.position).normalized * MoveSpeed * Time.fixedDeltaTime);
      }
    }

    if (_myTransform.position.x > 0)
    {
      _myTransform.localScale = _left;
    }
    else
    {
      _myTransform.localScale = _right;
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    // if(other.gameObject.tag == Constants.Tags.Mushmen) {
    //   _isColliding = true;
    // }
    if (other.gameObject.tag == Constants.Tags.HomeBase)
    {
      _isColliding = true;
    }
  }
}
