using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class YouDiedScene : SceneLoaderScript
    {

        [field: SerializeField]
        private Button MainMenuButton { get; set; }
    
        [field: SerializeField]
        private Button RestartLevelButton { get; set; }
    
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
        
        private Sequence MainSeq { get; set; }
        private RectTransform QuitButtonRect { get; set; }
        private RectTransform RestartButtonRect { get; set; }
        private RectTransform MenuButtonRect { get; set; }

        private void Start()
        {
            Cursor.visible = true;
            
            QuitButtonRect = QuitGameButton.GetComponent<RectTransform>();
            RestartButtonRect = RestartLevelButton.GetComponent<RectTransform>();
            MenuButtonRect = MainMenuButton.GetComponent<RectTransform>();

            QuitButtonRect.anchoredPosition = new Vector2(QuitButtonRect.anchoredPosition.x, 516);
            RestartButtonRect.anchoredPosition = new Vector2(RestartButtonRect.anchoredPosition.x, 291);
            MenuButtonRect.anchoredPosition = new Vector2(MenuButtonRect.anchoredPosition.x, 61);
            
            ShowButtons();
        }

        private void Awake()
        {
            MainMenuButton.onClick.AddListener(MainMenu);
            RestartLevelButton.onClick.AddListener(() => PlayLevel("Level01"));
            QuitGameButton.onClick.AddListener(QuitGame);
        }

        private void ShowButtons()
        {
            MainSeq = DOTween.Sequence();
            MainSeq.Append(QuitButtonRect.DOAnchorPosY(80, .7f).SetEase(Ease.OutBounce));
            MainSeq.Append(RestartButtonRect.DOAnchorPosY(0, .5f).SetEase(Ease.OutBounce));
            MainSeq.Append(MenuButtonRect.DOAnchorPosY(-80, .3f).SetEase(Ease.OutBounce));

        }
        
    }
}

