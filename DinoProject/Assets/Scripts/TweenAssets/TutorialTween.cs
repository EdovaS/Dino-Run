using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DinoRunGame.Tween
{
    public class TutorialTween : MonoBehaviour
    {
        private static bool _happendOnce;

        public bool GetHappendOnce() { return _happendOnce; } 
        
        [SerializeField] private Image _crouchInstruction;
        [SerializeField] private Image _jumpInstruction;

        private void Start()
        {
            this.Wait(0.3f, () =>
            {
                
                if(_happendOnce) return;
                _crouchInstruction.gameObject.SetActive(true);
                _jumpInstruction.gameObject.SetActive(true); 
                _crouchInstruction.DOFade(0, 5f).SetEase(Ease.InOutSine);
                _jumpInstruction.DOFade(0, 5f).SetEase(Ease.InOutSine);
                this.Wait(5f, () =>
                {
                    _crouchInstruction.gameObject.SetActive(false);
                    _jumpInstruction.gameObject.SetActive(false);
                    _happendOnce = true;        
                });
                
            });
            
        }
    }
}
