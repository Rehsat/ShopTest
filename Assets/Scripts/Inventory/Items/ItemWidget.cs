using UnityEngine.UI;
using UnityEngine;
using Inventories.Items;

namespace Inventories.UI
{
    public class ItemWidget : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Text _cost;
        [SerializeField] private Image _icon;

        public void Render(ItemData itemData)
        {
            Render(itemData, itemData.Cost);
        }
        public void Render(ItemData itemData, int cost)
        {
            _name.text = itemData.Name;
            _cost.text = cost.ToString();
            _icon.sprite = itemData.Icon;
        }
    }
}
