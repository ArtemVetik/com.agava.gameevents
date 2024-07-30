using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Agava.GameEvents
{
    public static class GameEvents
    {
        private static string _host;

        public static void Initialize(string host)
        {
            _host = host;
        }

        public static async Task<GameEventDataList> GetEvents(Action<string> onErrorCallback = null)
        {
            using var request = UnityWebRequest.Get($"{_host}/api/gameevent/get-events");
            await request.SendWebRequest();

            return request.Parse<GameEventDataList>(onErrorCallback);
        }

        public static async Task<ParticipantDataList> GetParticipants(string eventId, Action<string> onErrorCallback = null)
        {
            using var request = UnityWebRequest.Get($"{_host}/api/GameEvent/get-participants/{eventId}");
            await request.SendWebRequest();

            return request.Parse<ParticipantDataList>(onErrorCallback);
        }

        public static async Task JoinEvent(string eventId, string participantId, string participantName, Action<string> onErrorCallback = null)
        {
            var requestData = new JoinEventData
            {
                id = participantId,
                name = participantName,
            };

            using var request = UnityWebRequest.Post($"{_host}/api/GameEvent/join/{eventId}", JsonUtility.ToJson(requestData), "application/json");
            await request.SendWebRequest();
            request.EnsureStatusCode(onErrorCallback);
        }

        public static async Task AddScore(string eventId, string participantId, int score, Action<string> onErrorCallback = null)
        {
            var requestData = new AddScoreData
            {
                participant_id = participantId,
                score = score,
            };

            using var request = UnityWebRequest.Post($"{_host}/api/GameEvent/add-score/{eventId}", JsonUtility.ToJson(requestData), "application/json");
            await request.SendWebRequest();
            request.EnsureStatusCode(onErrorCallback);
        }
    }
}
