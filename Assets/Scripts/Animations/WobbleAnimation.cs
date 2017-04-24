using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class WobbleAnimation : MonoBehaviour
    {
        private Vector2 _floatY;
        private float _originalY;
        public float FloatStrength;

        void Start()
        {
            _originalY = transform.position.y;
        }

        void Update()
        {
            transform.position = new Vector3(transform.position.x, _originalY + ((float)Math.Sin(Time.time) * FloatStrength), transform.position.z);
        }
    }
}
