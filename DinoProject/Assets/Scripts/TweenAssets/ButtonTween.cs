using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DinoRunGame.Tween
{
    public class ButtonTween : MonoBehaviour
    {
        private Transform _buttonTransform;

        private void Start()
        {
            _buttonTransform = GetComponent<Transform>();
            _buttonTransform.DOScale(0.5f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
            
        }

    }    
}

