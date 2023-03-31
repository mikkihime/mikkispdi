using System;
using UnityEngine;
using UnityEngine.UI;

namespace Shop
{
    public class ItemHolderView : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject SoldOutTag { get; set; }
        
        [field: SerializeField]
        private Image ItemImage { get; set; }
        
        public ItemData Data { get; set; }
        
        [field: SerializeField]
        private Button ItemButton { get; set; }

        public void Setup(ItemData itemData, Action callback)
        {
            Data = itemData;
            ItemImage.sprite = Data.ItemSprite;
            SoldOutTag.SetActive(Data.Sold);
            
            ItemButton.onClick.AddListener(callback.Invoke);
        }

        public void Sold()
        {
            SoldOutTag.SetActive(true);
        }

    }
}

