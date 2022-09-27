using System;
using DG.Tweening;
using UnityEngine;

namespace SceneControllers
{
    public class PauseUIAnim : MonoBehaviour
    {
        [field: SerializeField]
        private RectTransform PauseMenuUI { get; set; }
        
        [field: SerializeField]
        private CanvasGroup Overlay { get; set; }
        
        [field: SerializeField]
        private CanvasGroup Content { get; set; }
        
        [field: SerializeField]
        private CanvasGroup PlayerUI { get; set; }
        
        private Sequence MainSeq { get; set; }
        
        public void Setup()
        {
            PauseMenuUI.anchorMin = new Vector2(0, 1);
            Overlay.alpha = 0;
            Content.alpha = 0;
        }

        public void ShowPauseAnimation(Action onComplete)
        {
            MainSeq = DOTween.Sequence();
            MainSeq.Append(PlayerUI.DOFade(0, 0.3f));
            MainSeq.Append(Overlay.DOFade(1, 0.3f));
            MainSeq.Append(PauseMenuUI.DOAnchorMin(new Vector2(0,0), .3f));
            MainSeq.Append(Content.DOFade(1, 0.3f));
            MainSeq.OnComplete(() => onComplete.Invoke());
        }

        public void HidePauseAnimation()
        {
            MainSeq = DOTween.Sequence();
            MainSeq.Append(Content.DOFade(0, 0.3f));
            MainSeq.Append(PauseMenuUI.DOAnchorMin(new Vector2(0,1), .3f));
            MainSeq.Append(Overlay.DOFade(0, 0.3f));
            MainSeq.Append(PlayerUI.DOFade(1, 0.3f));
        }
    }
}
