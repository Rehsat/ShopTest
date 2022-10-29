using UnityEngine.EventSystems;
using UnityEngine;
using Inventories.Utils;

namespace Inventories.UI
{
    public class UIDragAndDropable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Transform _currentParrent;
        private Transform _draggingParent;

        public void Init(Transform dragingParrent)
        {
            _draggingParent = dragingParrent;
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            _currentParrent = transform.parent;
            transform.parent = _draggingParent;
        }
        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            transform.parent = _currentParrent;
            var container = EventSystem.current.GetFirstcomponentUnderPointer<DropContainer>(eventData);
            if (container == null) return;

            container.DropActonInvoke(this.gameObject);
        }
    }
}
