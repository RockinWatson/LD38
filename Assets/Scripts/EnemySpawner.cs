using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] enemies;
        
        //Time to spawn
        public float waitForNext = 10;
        public float countDown = 10;

        //X Range
        public float xMin;
        public float xMax;

        //Y Range
        public float yMin;
        public float yMax;

        void start()
        {
        }

        void Update()
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                SpawnEnemy();
                countDown = waitForNext;
            }
        }

        void SpawnEnemy()
        {
            Vector2 pos = new Vector2(Random.Range(xMin,xMax), Random.Range(yMin,yMax));
            GameObject enemyPrefab = enemies[Random.Range(0,enemies.Length)];

            Instantiate(enemyPrefab, pos, transform.rotation);
        }
    }
}
