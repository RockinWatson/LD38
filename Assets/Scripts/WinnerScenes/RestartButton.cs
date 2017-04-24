using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.WinnerScenes
{
    public class RestartButton :MonoBehaviour
    {
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(Constants.Scenes.TitleScene);
            }
        }
    }
}
