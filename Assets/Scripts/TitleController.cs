using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class TitleController : MonoBehaviour
    {
        private bool SPACE_UP() { return (Input.GetKey(KeyCode.Space)); }

        void Update()
        {
            if (SPACE_UP())
            {
                SceneManager.LoadScene(Constants.Scenes.InstructionsScene);
            }
        }
    }
}
