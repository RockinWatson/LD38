using UnityEngine;

namespace Assets.Scripts
{
    public class CloudMovement : MonoBehaviour
    {
        private float _randomSpeed;

        void Start()
        {
            _randomSpeed = Random.Range(0.01f, 0.05f);
        }

        void Update()
        {
            transform.Translate(Vector2.right * _randomSpeed);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.Tags.CloudKiller))
            {
                Destroy(this.gameObject);
            }            
        }
    }
}
