using System;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSetView : MonoBehaviour
{
    public LeaderboardView LeaderboardWidget;
    public GameObject NoSetsMessage;    // A message to show if you haven't set up any leaderboard sets yet
    
    public Action<GKLeaderboardSet> OnLeaderboardSetSelected;
    public Action<GKLeaderboard,GKLeaderboardPlayerScope,GKLeaderboardTimeScope> OnLeaderboardSelected;
    public Action<GKLeaderboard,int> OnSendScore;
    
    public Button NextLeaderboardSetButton;
    public Button PrevLeaderboardSetButton;

    public Button NextLeaderboardButton;
    public Button PrevLeaderboardButton;
    
    private GKLeaderboardSet[] sets;
    private int setIndex;
    private GKLeaderboard[] leaderboards;
    private int leaderboardIndex;

    void Awake()
    {
        NextLeaderboardSetButton.onClick.AddListener(NextSet);
        PrevLeaderboardSetButton.onClick.AddListener(PrevSet);
        NextLeaderboardButton.onClick.AddListener(NextLeaderboard);
        PrevLeaderboardButton.onClick.AddListener(PrevLeaderboard);

        // When the user changes the time or player scope options, refresh the leaderboard data
        LeaderboardWidget.OnTimeScopeChanged = (val) => InvokeLeaderboardSelected();
        LeaderboardWidget.OnPlayerScopeChanged = (val) => InvokeLeaderboardSelected();
    }
    
    public void SetLeaderboardSets(GKLeaderboardSet[] sets)
    {
        this.sets = sets;
        setIndex = 0;
        var hasSets = sets != null && sets.Length > 0;
        
        NextLeaderboardSetButton.interactable = hasSets;
        PrevLeaderboardSetButton.interactable = hasSets;
        
        if(hasSets)
            OnLeaderboardSetSelected?.Invoke(sets[0]);
        
        // Display a message if there are no active sets
        NoSetsMessage.SetActive(!hasSets);
    }

    public void SetLeaderboards(GKLeaderboard[] leaderboards)
    {
        Debug.Log("Set Leaderboards");
        
        this.leaderboards = leaderboards;
        var hasLeaderboards = this.leaderboards.Length > 0;
        leaderboardIndex = 0;
        
        NextLeaderboardButton.interactable = hasLeaderboards;
        PrevLeaderboardButton.interactable = hasLeaderboards;

        SetSelectedLeaderboard(0);
    }

    void PrevSet()
    {
        if (sets.Length == 0)
            return;
        
        if (setIndex > 0)
            setIndex--;
        
        if(sets.Length > 0)
            OnLeaderboardSetSelected?.Invoke(sets[setIndex]);
    }
    
    void NextSet()
    {
        if (sets == null)
            return;
        
        if (setIndex < sets.Length - 1)
            setIndex++;
        
        if(sets.Length > 0)
            OnLeaderboardSetSelected?.Invoke(sets[setIndex]);
    }

    void PrevLeaderboard()
    {
        if (leaderboards == null)
            return;
        
        if (leaderboardIndex > 0)
            SetSelectedLeaderboard(leaderboardIndex - 1);
    }
    
    void NextLeaderboard()
    {
        if (leaderboards == null)
            return;
        
        if (leaderboardIndex < leaderboards.Length - 1)
             SetSelectedLeaderboard(leaderboardIndex + 1);
    }

    private void SetSelectedLeaderboard(int idx)
    {
        if (leaderboards.Length <= 0) return;
        
        leaderboardIndex = idx;
            
        var selectedLeaderboard = leaderboards[idx];
        LeaderboardWidget.SetLeaderboard(selectedLeaderboard);
        InvokeLeaderboardSelected();

        PrevLeaderboardButton.interactable = idx > 0;
        NextLeaderboardButton.interactable = idx < leaderboards.Length - 1;
    }

    public void InvokeLeaderboardSelected()
    {
        if (leaderboards == null || leaderboards.Length == 0)
            return;
        
        OnLeaderboardSelected?.Invoke(
            leaderboards[leaderboardIndex], 
            LeaderboardWidget.CurrentPlayerScope,
            LeaderboardWidget.CurrentTimeScope);
    }

    public void SetLeaderboardEntries(GKLeaderboardEntry localPlayerEntry, GKLeaderboardEntry[] entries)
    {
        LeaderboardWidget.SetEntries(localPlayerEntry, entries);
    }
}