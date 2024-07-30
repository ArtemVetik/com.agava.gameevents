using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class NotificationData
    {
        [field: Preserve]
        public string event_id;

        [field: Preserve]
        public EventStatus status;
    }
}