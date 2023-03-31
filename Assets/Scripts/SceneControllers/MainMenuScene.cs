using System;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class MainMenuScene : SceneLoaderScript
    {
        
        [field: SerializeField]
        private Button LoadGameButton { get; set; }
        
        [field: SerializeField]
        private Button NewGameButton { get; set; }
        
        [field: SerializeField]
        private Button QuitGameButton { get; set; }
        
        [field: SerializeField]
        private Button ShopButton { get; set; }
        
        [field: SerializeField]
        private SaveInfo SaveInfo { get; set; }
        
        [field: SerializeField]
        private Texture2D CursorArrow { get; set; }
        
        [field: SerializeField]
        private ParticleSystem CursorParticles { get; set; }

        private void Awake()
        {
            LoadGameButton.onClick.AddListener(() => PlayLevel("Level01"));

            ShopButton.onClick.AddListener(() => PlayLevel("Shop"));

            NewGameButton.onClick.AddListener(NewGame);

            QuitGameButton.onClick.AddListener(QuitGame);
        }

        private void Start()
        {
            Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.ForceSoftware);
            CursorParticles.Play();
        }

        private void Update()
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CursorParticles.transform.position = new Vector3(cursorPos.x, cursorPos.y);
        }

        private void NewGame()
        {
            SaveInfo.ResetData();
            PlayLevel("Level01");
        }

    }
}