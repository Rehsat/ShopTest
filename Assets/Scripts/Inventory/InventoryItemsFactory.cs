using Inventories.Items;
using UnityEngine;

namespace Inventories
{
    public class InventoryItemsFactory : MonoBehaviour
    {
        [SerializeField] private ShopItem _itemPrefab;
        public ShopItem CreateItem(ItemData itemData, Transform dragingParrent)
        {
            var newItem = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
            newItem.Init(dragingParrent, itemData);
            return newItem;
        }
    }
}
