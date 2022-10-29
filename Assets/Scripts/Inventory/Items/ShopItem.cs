using UnityEngine;
using System;
using Inventories.UI;

namespace Inventories.Items
{
    [RequireComponent(typeof(UIDragAndDropable))]
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private ItemWidget _itemWidget;

        private int _costBuff;
        public int CostBuff
        {
            get => _costBuff;
            set
            {
                _costBuff = value;
                RenderWidget();
            }
        }
        public int Cost
        {
            get => _itemData.Cost + Mathf.RoundToInt(((float)_itemData.Cost * ((float)CostBuff / 100)));
        }
        private UIDragAndDropable _dragAndDropController;

        private ItemData _itemData;
        public ItemData ItemData => _itemData;

        public Action<ShopItem> OnSell;

        private void Awake()
        {
            _dragAndDropController = GetComponent<UIDragAndDropable>();
        }
        public void ChangeOwner(Transform parrent)
        {
            OnSell?.Invoke(this);
            transform.parent = parrent;
        }
        public void Init(Transform dragingTransform, ItemData itemData)
        {
            _dragAndDropController.Init(dragingTransform);
            _itemData = itemData;
            RenderWidget();
        }
        private void RenderWidget()
        {
            _itemWidget.Render(_itemData, Cost);
        }
    }
}
