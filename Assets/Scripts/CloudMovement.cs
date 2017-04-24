using UnityEngine;

namespace Assets.Scripts
{
    public class CloudMovement : MonoBehaviour
    {
        private bool _randomSpeed;

        void Start()
        {
            //_randomSpeed = Random.Range(0.1, 0.9);
        }

        void Update()
        {
            transform.Translate(Vector2.right * 0.1f);
        }
    }
}
