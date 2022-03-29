using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace Obstacles
{
    public class Spikes : MonoBehaviour
    {
        private Sequence mainSequence;
        [SerializeField] private float topPosition;
        [SerializeField] private float bottomPosition;

        private void Start()
        {
            mainSequence = DOTween.Sequence();
            AnimateSpikes();
        }

        private void AnimateSpikes()
        {
            mainSequence.Append(transform.DOLocalMoveY(bottomPosition, 1f));
            mainSequence.AppendInterval(1f);
            mainSequence.Append(transform.DOLocalMoveY(topPosition, 1f));
            mainSequence.AppendInterval(1f);
            mainSequence.SetLoops(-1);
            mainSequence.Play();
        }
    }
}
