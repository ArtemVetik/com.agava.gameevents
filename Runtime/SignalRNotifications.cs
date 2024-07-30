using UnityEngine;
using System.Runtime.InteropServices;
using System;
using AOT;

namespace Agava.GameEvents
{
    public static class SignalRNotifications
    {
        private static event Action<NotificationData> s_onGameEventStatusChanged;

        public static void Initialize(string url, Action<NotificationData> onGameEventStatusChanged = null)
        {
            s_onGameEventStatusChanged = onGameEventStatusChanged;
#if UNITY_WEBGL && !UNITY_EDITOR
            InitializeSignalR(url, OnGameEventStatusChanged);
#else
            Debug.LogError($"{nameof(SignalRNotifications)} is only supported on WebGL.");
#endif
        }

        [DllImport("__Internal")]
        private static extern void InitializeSignalR(string url, Action<string> onGameEventStatusChanged);

        [DllImport("__Internal")]
        private static extern void SendMessageToUser(string userId, string message);

        [MonoPInvokeCallback(typeof(Action<string>))]
        private static void OnGameEventStatusChanged(string message)
        {
            NotificationData notification = JsonUtility.FromJson<NotificationData>(message);
            s_onGameEventStatusChanged?.Invoke(notification);
        }
    }
}