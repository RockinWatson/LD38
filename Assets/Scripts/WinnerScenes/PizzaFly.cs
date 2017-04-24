using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.WinnerScenes
{
    public class PizzaFly : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(Vector2.up * 0.05f);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.Tags.NextSceneTrigger))
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(Constants.Scenes.Winner2);
            }
        }
    }
}
