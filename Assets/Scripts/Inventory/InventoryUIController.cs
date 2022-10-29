using UnityEngine;
using System.Collections.Generic;
using Inventories.Items;
using Inventories.UI;

namespace Inventories
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] private int _markupPercent;

        [SerializeField] private Transform _dragingTransform;
        [SerializeField] private Transform _itemsParrent;

        [SerializeField] private Inventory _inventory;
        [SerializeField] private InventoryItemsFactory _inventoryItemsFactory;
        [SerializeField] private DropContainer _containerForDragAndDrop;

        private List<ShopItem> _items;
        private void Awake()
        {
            _items = new List<ShopItem>();
        }
        private void OnEnable()
        {
            foreach (var data in _inventory.ItemsData)
            {
                var newItem = _inventoryItemsFactory.CreateItem(data, _dragingTransform);
                newItem.transform.parent = _itemsParrent;
                AddUIItem(newItem);
            }

            _containerForDragAndDrop.OnObjectDrop += TryTakeItem;
            _inventory.OnSell += RemoveUIItem;
        }

        private void SetMarkUpForItem(ShopItem item)
        {
            item.CostBuff = _markupPercent;
        }
        private void TryTakeItem(GameObject potentialItem)
        {
            var item = potentialItem.GetComponent<ShopItem>();
            if (item == null)
            {
                return;
            }
            else if (_inventory.TryBuy(item))
            {
                AddUIItem(item);
            }
        }
        private void AddUIItem(ShopItem item)
        {
            item.ChangeOwner(_itemsParrent);
            SetMarkUpForItem(item);
            _inventory.AddUIItem(item);
        }
        private void RemoveUIItem(ShopItem item)
        {
            _items.Remove(item);
        }
        private void OnDisable()
        {
            _containerForDragAndDrop.OnObjectDrop -= TryTakeItem;
            _inventory.OnSell -= RemoveUIItem;
        }
    }
}
