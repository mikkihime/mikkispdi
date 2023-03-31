using System.Collections.Generic;
using PlayerScripts;
using SaveAndLoad;
using Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneControllers
{
    public class ShopController : SceneLoaderScript
    {
        [field: SerializeField]
        private Button CloseShopButton { get; set; }
        
        [field: SerializeField]
        private Button BuyButton { get; set; }
        
        [field: SerializeField]
        private SaveInfo SaveInfo { get; set; }
        
        [field: SerializeField]
        private Texture2D CursorArrow { get; set; }

        [field: SerializeField]
        private Text CherriesHolder { get; set; }
        
        [field: SerializeField]
        private ShopView ShopView { get; set; }
        
        private int Cherries { get; set; }

        private void Awake()
        {
            CloseShopButton.onClick.AddListener(MainMenu);
            BuyButton.onClick.AddListener(Buy);
        }

        public void Buy()
        {
            if (Cherries >= ShopView.ItemToBuy.Price &&
                !ShopView.ItemToBuy.Sold)
            {
                Debug.Log("Buy");
                Debug.Log($"Cherries before purchase {Cherries}");
                Cherries -= ShopView.ItemToBuy.Price;
                CherriesHolder.text = Cherries.ToString();
                PlayerPrefs.SetInt("PlayerCherries", Cherries);
                ShopView.FindSoldItem(ShopView.ItemToBuy);
                ShopView.ItemToBuy.Sold = true;
                ShopView.ItemDisplay.Sold();
                Debug.Log($"Cherries after purchase {Cherries}");
            }
            else
            {
                BuyButton.interactable = false;
            }
        }
        
        private void Start()
        {
            Cherries = PlayerPrefs.GetInt("PlayerCherries");
            Cursor.SetCursor(CursorArrow, Vector2.zero, CursorMode.ForceSoftware);
            CherriesHolder.text = Cherries.ToString();
        }
        
        private void Update()
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}