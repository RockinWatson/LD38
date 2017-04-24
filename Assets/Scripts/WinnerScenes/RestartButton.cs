using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.WinnerScenes
{
    public class RestartButton :MonoBehaviour
    {
        private float _originalY;
        public float FloatSpeed = 6;
        public float FloatStrength = 0.04f;

        private bool _isHovering;

        void Start()
        {
            _originalY = transform.position.y;
        }

        public void OnMouseOver()
        {
            if (_isHovering)
            {
                transform.position = new Vector3(transform.position.x, _originalY + ((float)Math.Sin(Time.time * FloatSpeed) * FloatStrength), transform.position.z);
            }
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(Constants.Scenes.TitleScene);
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
