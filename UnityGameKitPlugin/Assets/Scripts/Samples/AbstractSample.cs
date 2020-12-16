﻿using HovelHouse.GameKit;
using UnityEngine;

public abstract class AbstractSample : MonoBehaviour
{
    private void Start()
    {
        GameKitInitializer.Init();
        GKLocalPlayer.LocalPlayer.AuthenticateHandler = (controller, error) =>
        {
            if(controller != null)
                controller.Present();

            if (error != null)
                Debug.LogError(error);

            if (GKLocalPlayer.LocalPlayer.Authenticated)
                OnAuthenticated();
        };
    }

    protected abstract void OnAuthenticated();

    protected void DefaultCompletionHandler(NSError error)
    {
        if (error != null)
            LogNSError(error);
    }
    
    protected static void LogNSError(NSError error)
    {
        Debug.LogError($"domain: {error.Domain} code: {error.Code} description: {error.LocalizedDescription}");
    }
}