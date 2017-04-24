using UnityEngine;

namespace Assets.Scripts.GameOverScene
{
    public class ArmMovin : MonoBehaviour
    {
        void Update()
        {
            transform.Translate(Vector2.right * 0.03f);
        }
    }
}
