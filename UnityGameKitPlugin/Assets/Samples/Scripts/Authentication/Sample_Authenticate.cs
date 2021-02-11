using System;
using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

public class Sample_Authenticate : MonoBehaviour
{
    [Serializable]
    public class ButtonBinding
    {
        public Button button;
        public AbstractSample sample;
    }
    
    public GameObject EditorWarning;
    public ButtonBinding[] buttonBindings;
    private bool _hasRunSetup;

    private void Start()
    {
        // If were trying to run the sample in the editor let the user know this isn't gonna work
        if (Application.isEditor)
        {
            EditorWarning.gameObject.SetActive(true);
        }
        else
        {
            GameKitInitializer.Init();
            
            // This may look strange, but this is apples recommended way of handling authentication
            // it is STRONGLY recommended that you read the details of how this callback works before you attempt
            // to use it in your game
            // see: https://developer.apple.com/documentation/gamekit/gklocalplayer/1515399-authenticatehandler?language=objc
            // and: https://developer.apple.com/documentation/gamekit/authenticating_a_player?language=objc
            // for more details
            
            // Please be aware the authentication handler is called everytime the applicaton resumes from the being put
            // into the background, even if the player's authentication status has not changed
            GKLocalPlayer.LocalPlayer.AuthenticateHandler = (controller, error) =>
            {
                if (controller != null)
                    controller.Present();

                if (error != null)
                    Debug.LogError(error);

                if (GKLocalPlayer.LocalPlayer.Authenticated)
                    OnAuthenticated();
            };
        }
    }

    protected void OnAuthenticated()
    {
        RunSetup();
    }

    private void RunSetup()
    {
        if (_hasRunSetup)
            return;

        _hasRunSetup = true;
        
        Debug.Log("local player is authenticated");
        // Enable the whole UI now
        var children = GetComponentsInChildren<Selectable>(true);
        foreach (var child in children)
        {
            child.interactable = true;
        }

        var buttons = GetComponentsInChildren<Button>(true);
        foreach (var button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }
    
    private void OnButtonClick(Button whichButton)
    {
        // When the user clicks a button, run the sample that this button is set to in button bindings
        var entry = buttonBindings.FirstOrDefault(e => e.button == whichButton);
        if (entry != null)
        {
            entry.sample.Show(OnSampleFinished);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError($"no sample is set for button:{whichButton.name}", whichButton);
        }
    }

    private void OnSampleFinished()
    {
        Debug.Log("sample has finished running. Showing UI");
        gameObject.SetActive(true);
    }
}