using DinoRunGame.Managers.DifficultyManager;
using DinoRunGame.ObjectPooling;
using UnityEngine;

namespace DinoRunGame.Core
{
    public class Obstacle : MonoBehaviour
    {
        [HideInInspector] public PoolType PoolType;
        private ObjectPooler _objectPooler;
        
        private DifficultyManager difficultyManager;

        private void Start()
        {
            difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
            _objectPooler = FindObjectOfType<ObjectPooler>();
        }

        private void Update()
        {
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState1)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed1);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState2)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed2);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState3)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed3);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState4)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed4);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState5)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed5);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState6)
            {
                MoveObstacle(difficultyManager.ObstacleMovingSpeed6);
            }

        }

        private void MoveObstacle(float ObstacleMovingSpeed)
        {
            transform.position = new Vector2(transform.position.x - ObstacleMovingSpeed * Time.smoothDeltaTime,
                transform.position.y);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                gameObject.SetActive(false);
                _objectPooler.AddToPool(this.PoolType, gameObject);
            } 
            
        }
    }
}
