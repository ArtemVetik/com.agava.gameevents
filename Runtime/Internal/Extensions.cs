using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Agava.GameEvents
{
    internal static class Extensions
    {
        public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOperation)
        {
            return new UnityWebRequestAwaiter(asyncOperation);
        }

        public static T Parse<T>(this UnityWebRequest request, Action<string> onErrorCallback) where T : class
        {
            if (request.result != UnityWebRequest.Result.Success)
            {
                onErrorCallback?.Invoke($"{request.error}\n{request.downloadHandler.text}");
                return null;
            }

            if (request.responseCode == 200)
                return JsonUtility.FromJson<T>(request.downloadHandler.text);

            onErrorCallback?.Invoke($"Response code: {request.responseCode}");
            return null;
        }

        public static void EnsureStatusCode(this UnityWebRequest request, Action<string> onErrorCallback)
        {
            if (request.result != UnityWebRequest.Result.Success)
                onErrorCallback?.Invoke($"{request.error}\n{request.downloadHandler.text}");

            if (request.responseCode != 200)
                onErrorCallback?.Invoke($"Response code: {request.responseCode}");
        }
    }
}
