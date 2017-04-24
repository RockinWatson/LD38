using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class TitleController : MonoBehaviour
    {
        private bool SPACE_UP() { return (Input.GetKey(KeyCode.Space)); }
        private Scene _scene;

        void Update()
        {
            _scene = SceneManager.GetActiveScene();

            if (SPACE_UP())
            {
                if (_scene.name == Constants.Scenes.TitleScene)
                    SceneManager.LoadScene(Constants.Scenes.InstructionsScene);
                else if (_scene.name == Constants.Scenes.InstructionsScene)
                {
                    SceneManager.LoadScene(Constants.Scenes.GameScene);
                }
            }
        }
    }
}
