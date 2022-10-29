using UnityEngine;
namespace Inventories
{

    public class ActiveInventoriesData : MonoBehaviour
    {
        [SerializeField] private Inventory[] _inventories;
        public Inventory[] ActiveInventories => _inventories;
    }
}
