using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ShopView : MonoBehaviour
    {
        [field: SerializeField]
        private ItemShop ItemShop { get; set; }
        
        [field: SerializeField]
        public List<ItemHolderView> Items { get; set; }
        
        [field: SerializeField]
        private ItemHolderView ItemPrefab { get; set; }
        
        [field: SerializeField]
        public ItemHolderView ItemDisplay { get; set; }
        
        [field: SerializeField]
        private TextMeshProUGUI ItemDisplayText { get; set; }
        
        [field: SerializeField]
        private RectTransform ItemsGrid { get; set; }
        
        [field: SerializeField]
        public TextMeshProUGUI BuyButtonPrice { get; set; }
        
        public ItemData ItemToBuy { get; set; }

        private void Start()
        {
            foreach (var item in ItemShop.ItemDataList)
            {
                var itemToAdd = Instantiate(ItemPrefab, ItemsGrid);
                itemToAdd.Setup(item, () => GetItemData(item));
                Items.Add(itemToAdd);
            }
            GetItemData(Items.First().Data);
        }

        private void GetItemData(ItemData selectedItemData)
        {
            ItemToBuy = selectedItemData;
            ItemDisplay.Setup(selectedItemData, ()=>{});
            ItemDisplayText.text = selectedItemData.ItemDescription;
            BuyButtonPrice.text = $"x {ItemToBuy.Price}";
        }

        public void FindSoldItem(ItemData boughtItem)
        {
            var sold = Items.Find(x => x.Data == boughtItem);
            sold.Sold();
        }
    }
}

