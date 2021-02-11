using System;
using System.Collections.Generic;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// A UI view that shows a single leaderboard
public class LeaderboardView : MonoBehaviour
{
    public Button SendScoreButton;        // Button that sends a new score to the selected leaderboard
    public TMP_InputField ScoreInput;     // The input field for you to put your score in 
    public TMP_Text LeaderboardTitleTextMesh;
    public TMP_Dropdown TimeScopeDropdown;
    public TMP_Dropdown PlayerScopeDropdown;
    public LeaderboardEntryView LeaderboardEntryViewPrefab;
    public Transform LeaderboardEntryParent;
    
    public Action<GKLeaderboard,int> OnSendScore;
    public Action<string, int> OnSendScoreWithLeaderboardId; 
    public Action<GKLeaderboardPlayerScope> OnPlayerScopeChanged;
    public Action<GKLeaderboardTimeScope> OnTimeScopeChanged;

    [NonSerialized] public GKLeaderboardPlayerScope CurrentPlayerScope;
    [NonSerialized] public GKLeaderboardTimeScope CurrentTimeScope;

    private GKLeaderboard leaderboard;

    void Awake()
    {
        SendScoreButton.onClick.AddListener(OnSendScoreClick);
        
        // These dropdowns control what about the currently selected leaderboard to display
        // Fill the time and player scope dropdowns with all possible enumerations
        
        var timeOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var val in Enum.GetValues(typeof(GKLeaderboardTimeScope)))
        {
            timeOptions.Add(new TMP_Dropdown.OptionData(val.ToString()));
        }

        var playerScopeOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var val in Enum.GetValues(typeof(GKLeaderboardPlayerScope)))
        {
            playerScopeOptions.Add(new TMP_Dropdown.OptionData(val.ToString()));
        }
        
        TimeScopeDropdown.options = timeOptions;
        PlayerScopeDropdown.options = playerScopeOptions;
        
        TimeScopeDropdown.onValueChanged.AddListener((val) =>
        {
            CurrentTimeScope = (GKLeaderboardTimeScope) val;
            OnTimeScopeChanged?.Invoke(CurrentTimeScope);
        });
        PlayerScopeDropdown.onValueChanged.AddListener((val) =>
        {
            CurrentPlayerScope = (GKLeaderboardPlayerScope) val;
            OnPlayerScopeChanged?.Invoke(CurrentPlayerScope);
        });
    }

    private void OnSendScoreClick()
    {
        if (leaderboard == null)
            return;
        
        // see if we're submitting something of the form 'leaderboard_id:score'
        // or just submitting a score
        var parts = ScoreInput.text.Split(':');
        if(parts.Length >= 2)
        {
            OnSendScoreWithLeaderboardId?.Invoke(parts[0], int.Parse(parts[1]));
        }
        else if (int.TryParse(ScoreInput.text, out var score))
        {
            OnSendScore?.Invoke(leaderboard,score);
        }
    }

    public void SetEntries(GKLeaderboardEntry localPlayerEntry, GKLeaderboardEntry[] entries)
    {
        // Clear out any old entries
        for (var i = LeaderboardEntryParent.childCount - 1; i >= 0; i--)
        {
            Debug.Log(i);
            Destroy(LeaderboardEntryParent.GetChild(i).gameObject); 
        }

        if (entries == null)
            return;
        
        // make some new ones
        var localPlayer = GKLocalPlayer.LocalPlayer;
        foreach (var entry in entries)
        {
            var entryView = Instantiate(LeaderboardEntryViewPrefab, LeaderboardEntryParent);
            entryView.Name = entry.Player.DisplayName;
            entryView.Score = entry.FormattedScore;
            // highlight if the entry is the local player's
            entryView.Highlight = entry.Player == localPlayer;
        }
    }

    public void SetLeaderboard(GKLeaderboard leaderboard)
    {
        this.leaderboard = leaderboard;
        
        LeaderboardTitleTextMesh.text = leaderboard?.Title ?? "";
        SendScoreButton.interactable = this.leaderboard != null;
        
        var hasLeaderboard = leaderboard != null;
        TimeScopeDropdown.interactable = hasLeaderboard;
        PlayerScopeDropdown.interactable = hasLeaderboard;
    }
}
