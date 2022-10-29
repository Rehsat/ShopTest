using UnityEngine.UI;
using UnityEngine;

namespace Inventories.UI
{
    public class GoldWidget : MonoBehaviour
    {
        [SerializeField] private Text _goldText;
        public Text GoldText => _goldText;
    }
}
