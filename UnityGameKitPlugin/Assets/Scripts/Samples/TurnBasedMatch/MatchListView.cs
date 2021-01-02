using System;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

public class MatchListView : MonoBehaviour
{
    public MatchView matchView;
    public Button newMatchButton;
    public int maxSimultaneousMatches = 5;

    public Action OnNewMatch;
    
    void Awake()
    {
        newMatchButton.onClick.AddListener(() => OnNewMatch?.Invoke());
        newMatchButton.interactable = false;
    }
    public void SetMatches(GKTurnBasedMatch[] matches)
    {
        newMatchButton.interactable = matches == null || matches.Length < maxSimultaneousMatches;
    }

    public void ShowMatchView(GKTurnBasedMatch match, MyLocalPlayerDelegate localPlayerListener)
    {
        matchView.SetMatch(match, localPlayerListener);
        matchView.gameObject.SetActive(true);
    }
}
