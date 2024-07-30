using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class JoinEventData
    {
        [field: Preserve]
        public string id;

        [field: Preserve]
        public string name;
    }
}
