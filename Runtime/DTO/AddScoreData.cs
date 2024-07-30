using System;
using UnityEngine.Scripting;

namespace Agava.GameEvents
{
    [Serializable]
    public class AddScoreData
    {
        [field: Preserve]
        public string participant_id;
        
        [field: Preserve]
        public int score;
    }
}
