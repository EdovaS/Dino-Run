using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DinoRunGame.Managers.GameManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _buttonAndScreen;
        [SerializeField] private AudioClip _gameOverSound;
        
        [SerializeField] private GameObject _scoreRef;
        

        private void Awake()
        {
            _scoreRef.GetComponent<Text>().enabled = true;
            _buttonAndScreen.SetActive(false);
        }

        public void GameOver()
        {
            _buttonAndScreen.SetActive(true);
            SoundManager.SoundManager.Instance.PlaySound(_gameOverSound);
            _scoreRef.GetComponent<Text>().enabled = false;
        }
        
        // will call by RestartButton
        public void Restart()
        {
            SceneManager.LoadScene("Game");
        }
        
        
    }
}
