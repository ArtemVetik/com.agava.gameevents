using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Agava.GameEvents
{
    public static class GameEventsAdmin
    {
        private static string _host;
        private static string _apiKey;

        public static void Initialize(string host, string apiKey)
        {
            _host = host;
            _apiKey = apiKey;
        }

        public static async Task CreateEvent(string name, string description, Action<string> onErrorCallback = null)
        {
            var requestData = new CreateGameEventData
            {
                name = name,
                description = description,
            };

            using var request = UnityWebRequest.Post($"{_host}/api/GameEvent/create", JsonUtility.ToJson(requestData), "application/json");
            request.SetRequestHeader("ApiKey", _apiKey);
            await request.SendWebRequest();

            request.EnsureStatusCode(onErrorCallback);
        }

        public static async Task StartEvent(string eventId, Action<string> onErrorCallback = null)
        {
            using var request = UnityWebRequest.Post($"{_host}/api/GameEvent/start/{eventId}", string.Empty, "application/json");
            request.SetRequestHeader("ApiKey", _apiKey);
            await request.SendWebRequest();

            request.EnsureStatusCode(onErrorCallback);
        }

        public static async Task StopEvent(string eventId, Action<string> onErrorCallback = null)
        {
            using var request = UnityWebRequest.Post($"{_host}/api/GameEvent/stop/{eventId}", string.Empty, "application/json");
            request.SetRequestHeader("ApiKey", _apiKey);
            await request.SendWebRequest();

            request.EnsureStatusCode(onErrorCallback);
        }
    }
}
