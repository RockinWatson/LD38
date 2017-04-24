using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Timer : MonoBehaviour
    {
        public float timeLeft = 180.0f;
        public bool stop = true;

        private float _minutes;
        private float _seconds;

        public Text text;

        public void StartTimer(float from)
        {
            timeLeft = from;
            Update();
            StartCoroutine(UpdateCoroutine());
        }

        void Update()
        {
            if (stop) return;
            timeLeft -= Time.deltaTime;

            _minutes = Mathf.Floor(timeLeft / 60);
            _seconds = timeLeft % 60;
            if (_seconds > 59) _seconds = 59;
            if (_minutes < 0)
            {
                stop = true;
                _minutes = 0;
                _seconds = 0;
            }
        }

        private IEnumerator UpdateCoroutine()
        {
            while (!stop)
            {
                text.text = string.Format("{0:0}:{1:00}", _minutes, _seconds);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
