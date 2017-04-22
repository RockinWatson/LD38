using Assets.Scripts;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public SpriteRenderer sp;

    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;

    private bool isColliding;
    private Transform myTransform;
    private Vector3 left = new Vector3(-1,1,1);
    private Vector3 right = new Vector3(1, 1, 1);

    void Awake()
    {
        myTransform = transform;  
    }

    void Start () {
        //sp = GetComponent<SpriteRenderer>();
        GameObject homeBase = GameObject.FindGameObjectWithTag(Constants.Tags.HomeBase);
        target = homeBase.transform;
	}
	
	void Update () {

        if (isColliding)
        {
            moveSpeed = 0;
        }
        else
        {
            //Movin to the target
            myTransform.position += (target.position - myTransform.position).normalized * moveSpeed * Time.deltaTime;
        }

        if (myTransform.position.x > 0)
        {
            myTransform.localScale = left;
        }
        else
        {
            myTransform.localScale = right;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == Constants.Tags.HomeBase)
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }
}
