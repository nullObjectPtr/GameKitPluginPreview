using System;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractSample : MonoBehaviour
{
    public Button backButton;
    private Action OnBack;
    
    private void Start()
    {
        backButton.onClick.AddListener(OnBackClick);
    }

    private void OnEnable()
    {
        Run();
    }

    protected abstract void Run();

    protected virtual void OnBackClick()
    {
        if (OnBack == null) return;
        OnBack.Invoke();
        OnBack = null;
        this.gameObject.SetActive(false);
    }

    public void Show(Action action)
    {
        gameObject.SetActive(true);
        OnBack = action;
    }
    
    
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
