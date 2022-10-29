using System;
using UnityEngine;

namespace Inventories.UI
{
    public class DropContainer : MonoBehaviour
    {
        public Action<GameObject> OnObjectDrop;

        public void DropActonInvoke(GameObject draggedObject)
        {
            OnObjectDrop?.Invoke(draggedObject);
        }
    }
}