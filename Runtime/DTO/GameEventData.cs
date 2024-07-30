using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class GameEventData
    {
        [field: Preserve]
        public string id;

        [field: Preserve]
        public string name;

        [field: Preserve]
        public string description;

        [field: Preserve]
        public EventStatus status;
    }
}
