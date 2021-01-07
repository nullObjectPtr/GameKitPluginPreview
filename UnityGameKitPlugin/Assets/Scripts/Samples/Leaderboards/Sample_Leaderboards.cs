using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Sample_Leaderboards : AbstractSample
{
    public LeaderboardSetView setView;

    void Awake()
    {
        setView.OnLeaderboardSetSelected = OnLeaderboardSetSelected;
        setView.OnLeaderboardSelected = OnLeaderboardSelected;
        setView.LeaderboardWidget.OnSendScore = OnSendScore_Method1;
        setView.LeaderboardWidget.OnSendScoreWithLeaderboardId = OnSendScore_Method2;
    }
    protected override void OnAuthenticated()
    {
        Debug.Log("Player Authenticated");
        LoadAllLeaderboards();
    }
    
    private void LoadAllLeaderboards()
    {
        Debug.Log("load leaderboard sets");
        
        // Leaderboards are now divided into sets
        // LoadLeaderboardSets appears not to load anything
        // Unsure if this was a configuration problem on App Store Connect, or just an apple bug in the API
        // Either way, couldn't use it and it does not appear to be a bug in the plugin
        // GKLeaderboardSet.LoadLeaderboardSetsWithCompletionHandler((leaderboardSets, error) =>
        // {
        //     Debug.Log($"loaded {leaderboardSets?.Length ?? 0} leaderboard sets");
        //     if (error != null)
        //     {
        //         Debug.LogError($"error loading leaderboard sets: {error.LocalizedDescription}");
        //     }
        //     else
        //     {
        //         setView.SetLeaderboardSets(leaderboardSets);
        //     }
        // });
        
        // GKLeaderboard.LoadLeaderboardsWithIDs(new []{"recurring","hi_scores"}, OnLeaderboardsLoaded);
        
        // Deprecated way of doing this, but it still works
        GKLeaderboard.LoadLeaderboardsWithCompletionHandler(OnLeaderboardsLoaded);
    }

    private void OnLeaderboardsLoaded(GKLeaderboard[] leaderboards, NSError error)
    {
        var numLeaderboards = leaderboards?.Length ?? 0;
        var ids = numLeaderboards > 0 ? 
            string.Join(",", leaderboards.Select(x => x.BaseLeaderboardID)) : "";
        
        Debug.Log($"loaded {numLeaderboards} leaderboards. ({ids})");
        
        if(numLeaderboards > 0)
            setView.SetLeaderboards(leaderboards);
        
        if (error != null)
        {
            Debug.LogError(error.LocalizedDescription);
        }
    }

    private void OnLeaderboardSetSelected(GKLeaderboardSet set)
    {
        Debug.Log($"Load leaderboards for set '{set.Identifier}'");
        // Load all leaderboards in the selected set
        set.LoadLeaderboardsWithHandler((leaderboards, error) =>
        {
            Debug.Log($"loaded {leaderboards.Length} leaderboards for set '{set.Identifier}'");
            if (error != null)
            {
                Debug.LogError(error.LocalizedDescription);
            }
            else
            {
                setView.SetLeaderboards(leaderboards);
            }
        });
    }

    private void OnLeaderboardSelected(
        GKLeaderboard leaderboard, 
        GKLeaderboardPlayerScope scope, 
        GKLeaderboardTimeScope timeScope)
    {
        Debug.Log($"On Leaderboard Selected {leaderboard.BaseLeaderboardID}");
        
        // Leaderboards can get really huge, so we can't really load the entire leaderboard at once. The API exposes
        // two methods that will return a range of entries. One is LoadEntriesForPlayerScope (used here). The other is
        // LoadEntriesForPlayers which can be used to locate another player's (maybe a friends?) score to compare
        // against your own

        // Scope - loads either just your friends scores, or all players of the game
        // TimeScope - the time-range of the leaderboard you're interested in (daily,weekly,all-time,etc)
        
        leaderboard.LoadEntriesForPlayerScope(scope, timeScope, 1, 100, 
            (localPlayerEntry, entries, totalPlayerCount, error) =>
        {
            // localPlayerEntry - the leaderboard entry for the local player
            // entries - the leaderboard entries for all the other players within the rank range you requested
            // min rank is 1, max is 100
            // totalPlayerCount - the number of total entries we've loaded
            if (error != null)
            {
                Debug.LogError(error.LocalizedDescription);
            }
            else
            {
                setView.SetLeaderboardEntries(localPlayerEntry, entries);
            }
        } );
    }

    // There are two ways to submit scores, you can either use a reference to the leaderboard
    // or you can use the string-id of the leaderboard if you don't have a reference
    private void OnSendScore_Method1(GKLeaderboard leaderboard, int score)
    {
        Debug.Log($"submit score of {score} to leaderboard {leaderboard.BaseLeaderboardID}");
        leaderboard.SubmitScore(score, 0, GKLocalPlayer.LocalPlayer, SubmitScoreHandler);
    }

    // this is the second method of sending a score, using the leaderboard id (if you don't have a reference)
    private void OnSendScore_Method2(string leaderboardId, int score)
    {
        // score - the score to submit
        // context - optional extra value you can do what you wish with
        // player - the player we want to submit a score for, usually the local player
        // leaderboard ids - an array of leaderboard id's we want to send this score to (can send to multiple leaderboards)
        // completionHandler - a simple callback invoked when the score is submitted, error is not null if there was a problem
        var player = GKLocalPlayer.LocalPlayer;
        GKLeaderboard.SubmitScore(score, 0, player, new []{leaderboardId}, SubmitScoreHandler);
    }

    private void SubmitScoreHandler(NSError error)
    { 
        if (error != null)
        {
            Debug.LogError($"error submitting score to leaderboard");
            LogNSError(error);
        }
        else
        {
            // force a refresh of leaderboard entries
            Debug.Log($"Score updated for player");
            setView.InvokeLeaderboardSelected();
        }
    }
}