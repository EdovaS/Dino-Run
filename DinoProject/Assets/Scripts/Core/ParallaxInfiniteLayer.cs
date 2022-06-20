using DinoRunGame.Managers.DifficultyManager;
using UnityEngine;

namespace DinoRunGame.Core
{
    public class ParallaxInfiniteLayer : MonoBehaviour
    {
        
        [SerializeField] private float _layerMovingSpeed;
        [SerializeField] private float _startPosition;
        [SerializeField] private float _endPosition;

        private DifficultyManager difficultyManager;
        private float addValueToLayerMovingSpeed;
        private float layerMovingSpeed2;
        private float layerMovingSpeed3;
        private float layerMovingSpeed4;
        private float layerMovingSpeed5;
        private float layerMovingSpeed6;
        
        private void Start()
        {
            difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();

            _layerMovingSpeed = 5f;
            layerMovingSpeed2 = _layerMovingSpeed + 1.5f;
            layerMovingSpeed3 = layerMovingSpeed2 + 2f;
            layerMovingSpeed4 = layerMovingSpeed3 + 2.5f;
            layerMovingSpeed5 = layerMovingSpeed4 + 2.5f;
            layerMovingSpeed6 = layerMovingSpeed5 + 1f;
        }

        private void Update()
        {
            
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState1)
            {
                LayerMovement(_layerMovingSpeed);    
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState2)
            {
                LayerMovement(layerMovingSpeed2);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState3)
            {
                LayerMovement(layerMovingSpeed3);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState4)
            {
                LayerMovement(layerMovingSpeed4);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState5)
            {
                LayerMovement(layerMovingSpeed5);
            }
            if (difficultyManager.currentDifficultyState == DifficultyManager.DifficultyState.DifficultyState6)
            {
                LayerMovement(layerMovingSpeed6);
            }
        }

        private void LayerMovement(float layerMovingSpeed)
        {
            transform.position = new Vector2(transform.position.x - layerMovingSpeed * Time.smoothDeltaTime, transform.position.y);

            if (transform.position.x <= _endPosition)
            {
                transform.position = new Vector2(_startPosition, transform.position.y);
            }
        }
    }
}
