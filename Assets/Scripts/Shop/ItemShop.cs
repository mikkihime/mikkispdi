using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items")]
    public class ItemShop : ScriptableObject
    {
       [field: SerializeField]
       public List<ItemData> ItemDataList { get; set; }
    }

    [Serializable]
    public class ItemData
    {
        [field: SerializeField]
        public String ItemName { get; set; }
    
        [field: SerializeField]
        public String ItemDescription { get; set; }
    
        [field: SerializeField]
        public Sprite ItemSprite { get; set; }
    
        [field: SerializeField]
        public int Price { get; set; }
    
        [field: SerializeField]
        public bool Sold { get; set; }
    }
}
