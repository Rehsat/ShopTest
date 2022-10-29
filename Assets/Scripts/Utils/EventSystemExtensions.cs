using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Inventories.Utils
{
    static class EventSystemExtensions
    {
        public static T GetFirstcomponentUnderPointer<T>(this EventSystem system, PointerEventData eventData)
        {
            var result = new List<RaycastResult>();
            system.RaycastAll(eventData, result);

            foreach (var raycast in result)
                if (raycast.gameObject.TryGetComponent<T>(out T component))
                    return component;

            return default(T);
        }
    }
}
