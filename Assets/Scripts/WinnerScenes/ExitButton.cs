using UnityEngine;

namespace Assets.Scripts.WinnerScenes
{
    public class ExitButton : MonoBehaviour
    {
        public void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("The Game Should be Closed!");
                Application.Quit();
            }
        }
    }
}
