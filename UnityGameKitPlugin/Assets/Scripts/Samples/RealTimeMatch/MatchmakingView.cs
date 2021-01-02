using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingView : MonoBehaviour
{
    public TMP_InputField MinPlayerInput;
    public TMP_InputField MaxPlayerInput;
    public Button FindMatchButton;
    
    public Action<int,int> OnFindMatch;

    void Awake()
    {
        FindMatchButton.onClick.AddListener(OnFindMatchClick);
    }

    private void OnFindMatchClick()
    {
        if (int.TryParse(MinPlayerInput.text, out var minPlayers) &&
            int.TryParse(MaxPlayerInput.text, out var maxPlayers))
        {
            if (minPlayers >= 2 && maxPlayers >= minPlayers)
                OnFindMatch?.Invoke(minPlayers, maxPlayers);
        }
    }
}
