﻿using Assets.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform Target;
    public int MoveSpeed;

    private bool _isColliding;
    private Transform _myTransform;
    private readonly Vector3 _left = new Vector3(-1,1,1);
    private readonly Vector3 _right = new Vector3(1, 1, 1);

    void Awake()
    {
        _myTransform = transform;  
    }

    void Start () {
        var homeBase = GameObject.FindGameObjectWithTag(Constants.Tags.HomeBase);

        if (Target != null)
        {
            Target = homeBase.transform;
        }
        
	}
	
	void Update () {

        if (_isColliding)
        {
            MoveSpeed = 0;
        }
        else
        {
            if (Target != null)
            {
                //Movin to the target
                _myTransform.position += (Target.position - _myTransform.position).normalized * MoveSpeed * Time.deltaTime;
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
