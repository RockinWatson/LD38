using Assets.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public int moveSpeed;

    private bool _isColliding;
    private Transform _myTransform;
    private Vector3 _left = new Vector3(-1,1,1);
    private Vector3 _right = new Vector3(1, 1, 1);

    void Awake()
    {
        _myTransform = transform;  
    }

    void Start () {
        GameObject homeBase = GameObject.FindGameObjectWithTag(Constants.Tags.HomeBase);
        target = homeBase.transform;
	}
	
	void Update () {

        if (_isColliding)
        {
            moveSpeed = 0;
        }
        else
        {
            //Movin to the target
            _myTransform.position += (target.position - _myTransform.position).normalized * moveSpeed * Time.deltaTime;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Constants.Tags.HomeBase)
        {
            _isColliding = true;
        }
        else
        {
            _isColliding = false;
        }
    }
}
