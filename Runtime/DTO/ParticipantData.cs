using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class ParticipantData
    {
        [field:Preserve]
        public string participant_id;

        [field:Preserve]
        public string event_id;

        [field:Preserve]
        public string participant_name;

        [field:Preserve]
        public int score;
    }
}
