using System;
using UnityEngine;

namespace Assets.Scripts.WinnerScenes
{
    public class ExitButton : MonoBehaviour
    {
        private float _originalY;
        public float FloatSpeed = 6;
        public float FloatStrength = 0.4f;

        private bool _isHovering;

        void Start()
        {
            _originalY = transform.position.y;
        }

        void Update()
        {
        }

        public void OnMouseOver()
        {
            if (_isHovering)
            {
                transform.position = new Vector3(transform.position.x, _originalY + ((float)Math.Sin(Time.time * FloatSpeed) * FloatStrength), transform.position.z);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("The Game Should be Closed!");
                Application.Quit();
            }
        }

        void OnMouseEnter()
        {
            _isHovering = true;
        }

        void OnMouseExit()
        {
            _isHovering = false;
        }
    }
}
