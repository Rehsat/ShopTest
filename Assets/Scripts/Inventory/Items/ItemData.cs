using UnityEngine;
namespace Inventories.Items
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "Items/New ItemData")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private int _cost;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public int Cost => _cost;
        public string Name => _name;
        public Sprite Icon => _icon;
    }
}
