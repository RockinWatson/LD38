using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class TitleController : MonoBehaviour
    {

        /*public void Title_Audio()
        {
            var title_audio = GameObject.Find("TitleAudioController");
            title_audio.GetComponent<TitleAudioController>().TitleSpace();
        }*/


        private bool SPACE_UP() { return (Input.GetKey(KeyCode.Space)); }
        private Scene _scene;

        void Update()
        {
            _scene = SceneManager.GetActiveScene();

            if (SPACE_UP())
            {
                //Title_Audio();
                SceneManager.LoadScene(Constants.Scenes.InstructionsScene);
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
