using System;
using DinoRunGame.Core;
using DinoRunGame.Managers.ScoreManager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DinoRunGame.Managers.DifficultyManager
{
    public class DifficultyManager : MonoBehaviour
    {
        
        public float _addAmountOnDifficulty2;
        public float _addAmountOnDifficulty3;
        public float _addAmountOnDifficulty4;
        public float _addAmountOnDifficulty5;
        public float _addAmountOnDifficulty6;
        
        [HideInInspector] public float ObstacleMovingSpeed1;
        [HideInInspector] public float ObstacleMovingSpeed2;
        [HideInInspector] public float ObstacleMovingSpeed3;
        [HideInInspector] public float ObstacleMovingSpeed4;
        [HideInInspector] public float ObstacleMovingSpeed5;
        [HideInInspector] public float ObstacleMovingSpeed6;

        [SerializeField] private Score _score;
        [SerializeField] private ObstacleSpawner _obstacleSpawner;

        public DifficultyState currentDifficultyState = DifficultyState.DifficultyState1;

        private void Start()
        {
            ObstacleMovingSpeed1 = 8;
            ObstacleMovingSpeed2 = _addAmountOnDifficulty2 + ObstacleMovingSpeed1;
            ObstacleMovingSpeed3 = _addAmountOnDifficulty3 + ObstacleMovingSpeed2;
            ObstacleMovingSpeed4 = _addAmountOnDifficulty4 + ObstacleMovingSpeed3;
            ObstacleMovingSpeed5 = _addAmountOnDifficulty5 + ObstacleMovingSpeed4;
            ObstacleMovingSpeed6 = _addAmountOnDifficulty6 + ObstacleMovingSpeed5;
        }

        public enum DifficultyState
        {
            DifficultyState1, 
            DifficultyState2, 
            DifficultyState3, 
            DifficultyState4, 
            DifficultyState5,
            DifficultyState6
        }

        private void Update()
        {
            if (_score.GetScore() > 150)
            {
                currentDifficultyState = DifficultyState.DifficultyState2;
                _obstacleSpawner.SetInBtwSpawnTime(Random.Range(1.5f, 2.5f));
            }

            if (_score.GetScore() > 250)
            {
                currentDifficultyState = DifficultyState.DifficultyState3;
                _obstacleSpawner.SetInBtwSpawnTime(Random.Range(1f, 1.5f));
            }

            if (_score.GetScore() > 500)
            {
                currentDifficultyState = DifficultyState.DifficultyState4;
                _obstacleSpawner.SetInBtwSpawnTime(Random.Range(0.7f, 5f));
            }

            if (_score.GetScore() > 1000)
            {
                currentDifficultyState = DifficultyState.DifficultyState5;
                _obstacleSpawner.SetInBtwSpawnTime(Random.Range(0.5f, 4.5f));
            }

            if (_score.GetScore() > 1500)
            {
                currentDifficultyState = DifficultyState.DifficultyState6;
                _obstacleSpawner.SetInBtwSpawnTime(Random.Range(0.2f, 5f));
            }
        }
        
        
    }
}
