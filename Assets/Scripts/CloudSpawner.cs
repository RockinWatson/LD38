using UnityEngine;

namespace Assets.Scripts
{
    public class CloudSpawner : MonoBehaviour
    {
        public GameObject[] Clouds;
        
        //Time to spawn
        public float WaitForNext = 10;
        public float CountDown = 10;

        //X Range
        public float XMin;
        public float XMax;

        //Y Range
        public float YMin;
        public float YMax;

        void Update()
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
            {
                SpawnCloud();
                CountDown = WaitForNext;
            }
        }

        private void SpawnCloud()
        {
            var pos = new Vector2(Random.Range(XMin,XMax), Random.Range(YMin,YMax));
            var enemyPrefab = Clouds[Random.Range(0,Clouds.Length)];

            Instantiate(enemyPrefab, pos, transform.rotation);
        }
    }
}
