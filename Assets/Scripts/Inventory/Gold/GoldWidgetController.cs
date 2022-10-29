using Zenject;
using UnityEngine;

namespace Inventories.UI
{
    public class GoldWidgetController : MonoBehaviour
    {
        [SerializeField] private string _ownerId;
        [SerializeField] private GoldWidget _goldWidget;

        [Inject] private ActiveInventoriesData _activeInventories;
        private Inventory _goldContainer;

        private void Awake()
        {
            foreach (var inventory in _activeInventories.ActiveInventories)
            {
                if (inventory.OwnerName == _ownerId)
                {
                    _goldContainer = inventory;
                    return;
                }
            }
        }
        private void OnEnable()
        {
            _goldContainer.OnGoldValueChange += UpdateGoldWidget;
        }
        private void UpdateGoldWidget(int newValue)
        {
            _goldWidget.GoldText.text = newValue.ToString();
        }
        private void OnDisable()
        {
            _goldContainer.OnGoldValueChange -= UpdateGoldWidget;
        }
    }
}
