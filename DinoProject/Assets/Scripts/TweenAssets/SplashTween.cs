using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DinoRunGame.Tween
{
    public class SplashTween : MonoBehaviour
    {
        [SerializeField] private Transform _blackDinoTransform;
        [SerializeField] private TutorialTween _tutorialTweenScript;
        
        private void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                _blackDinoTransform.gameObject.SetActive(true);
                _blackDinoTransform.DOScale(0, 0.5f).SetEase(Ease.InOutSine);
            }

            if (SceneManager.GetActiveScene().buildIndex != 1) return;
            if (_blackDinoTransform == null)
            {
                Debug.LogWarning(_tutorialTweenScript.name + "Object is not assigned");
                return;
            }
            if (_tutorialTweenScript.GetHappendOnce() == false)
            {
                _blackDinoTransform.gameObject.SetActive(true);
                _blackDinoTransform.DOScale(0, 0.5f).SetEase(Ease.InOutSine);        
            }

        }
        
        public void LoadNextLevel() 
        {
            _blackDinoTransform.DOScale(30, 0.5f).SetEase(Ease.InOutSine);
            this.Wait(0.5f, () => { SceneManager.LoadScene("Game"); });
        }

    }
    
    
}
