using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace Obstacles
{
    public class Spikes : MonoBehaviour
    {
        [field: SerializeField] private RectTransform SpikesRectTransform;

        private void Start()
        {
            Sequence Animation = Sequence();
            Animation.Append(SpikesRectTransform.DOMoveY(-1, 1f));
                
        }
    }
}
