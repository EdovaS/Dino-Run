using DinoRunGame.ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DinoRunGame.Core
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private float _timeBetweenSpawn;
        private float timer;

        [SerializeField] private Transform _spawnLocation;

        private ObjectPooler _objectPooler;
        private PoolType PoolType;
        private float addToObstacleMovingSpeed;

        // Getters and Setters
        public float GetInBtwSpawnTime() { return _timeBetweenSpawn; }
        public void SetInBtwSpawnTime(float newInBtwSpawnTime) {  _timeBetweenSpawn = newInBtwSpawnTime; }
        
        private void Start()
        {
            _timeBetweenSpawn = 4f;
            _objectPooler = FindObjectOfType<ObjectPooler>();
            
        }
        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= _timeBetweenSpawn)
            {
                timer = 0;
                Spawn();
            }
        }

        private void Spawn()
        {
            PoolType = (PoolType)Random.Range(0,7);
            GameObject spawnObject = _objectPooler.GetFromPool(PoolType);
            spawnObject.transform.position = _spawnLocation.transform.position;
            spawnObject.transform.parent = transform;
            spawnObject.SetActive(true);
        }

    }
}