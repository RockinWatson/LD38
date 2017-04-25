using UnityEngine;

namespace Assets.Scripts.WinnerScenes
{
    public class FinalScore : MonoBehaviour
    {
        [SerializeField] private TextMesh _score;

        private void OnGUI()
        {
            _score.text = "Score: " + Constants.Globals.Score;
        }
    }
}
