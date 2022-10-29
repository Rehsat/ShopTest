using System;
using System.Collections.Generic;
using UnityEngine;
using Inventories.Items;

namespace Inventories
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private string _ownerName;
        [SerializeField] private int _gold;
        [SerializeField] private List<ItemData> _itemsData;
        public List<ItemData> ItemsData => _itemsData;
        public string OwnerName => _ownerName;
        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnGoldValueChange?.Invoke(_gold);
            }
        }

        public Action<ShopItem> OnSell;
        public Action<int> OnGoldValueChange;
        private void Start()
        {

            OnGoldValueChange?.Invoke(_gold);
        }
        public void AddUIItem(ShopItem item)
        {
            item.OnSell += HandleItemSell;
        }
        public bool TryBuy(ShopItem item)
        {
            if (Gold < item.Cost) return false;

            Gold -= item.Cost;
            _itemsData.Add(item.ItemData);
            return true;
        }
        private void HandleItemSell(ShopItem soldItem)
        {
            soldItem.OnSell -= HandleItemSell;

            Gold += soldItem.Cost;
            _itemsData.Remove(soldItem.ItemData);

            OnSell?.Invoke(soldItem);
        }
    }
}
