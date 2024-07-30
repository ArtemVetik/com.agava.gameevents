using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class CreateGameEventData
    {
        [field: Preserve]
        public string name;

        [field: Preserve]
        public string description;
    }
}
