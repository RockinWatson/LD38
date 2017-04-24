using System.Collections;
using UnityEngine;

namespace Assets.Scripts.WinnerScenes
{
    public class PizzaWorld : MonoBehaviour
    {
        public float Delay;

        public SpriteRenderer Sprite;

        void Start()
        {
            StartCoroutine(Fade());
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + Delay);
        }

        private IEnumerator Fade()
        {
            for (var f = 1f; f >= 0; f -= 0.01f)
            {
                var c = Sprite.material.color;
                c.a = f;
                Sprite.material.color = c;
                yield return null;
            }
        }
    }
}
