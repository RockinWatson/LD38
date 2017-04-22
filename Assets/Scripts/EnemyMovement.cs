using Assets.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    private bool isColliding;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;  
    }

    void Start () {
        GameObject homeBase = GameObject.FindGameObjectWithTag(Constants.Tags.HomeBase);
        target = homeBase.transform;
	}
	
	void Update () {
        //ROTATION STUFF
        //Vector3 dir = target.position - myTransform.position;
        //dir.z = 0.0f;

        //if (dir != Vector3.zero)
        //{
        //    myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.FromToRotation(Vector3.right, dir),rotationSpeed * Time.deltaTime);
        //}

        if (isColliding)
        {
            moveSpeed = 0;
        }
        else
        {
            //Movin to the target
            myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Constants.Tags.HomeBase)
        {
            Debug.Log("Is triggered");
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
