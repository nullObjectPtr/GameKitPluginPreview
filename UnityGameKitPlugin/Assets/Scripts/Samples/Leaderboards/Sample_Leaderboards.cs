using System;
using HovelHouse.GameKit;
using UnityEngine;

public class Sample_Leaderboards : AbstractSample
{
    public LeaderboardSetView setView;

    void Awake()
    {
        setView.OnLeaderboardSetSelected = OnLeaderboardSetSelected;
        setView.OnLeaderboardSelected = OnLeaderboardSelected;
    }
    protected override void OnAuthenticated()
    {
        Debug.Log("Player Authenticated");
        LoadAllLeaderboards();
    }
    
    private void LoadAllLeaderboards()
    {
        // Leaderboards are now divided into sets
        Debug.Log("load leaderboard sets");
        GKLeaderboardSet.LoadLeaderboardSetsWithCompletionHandler((leaderboardSets, error) =>
        {
            Debug.Log($"loaded {leaderboardSets?.Length ?? 0} leaderboard sets");
            if (error != null)
            {
                Debug.LogError(error.LocalizedDescription);
            }
            else
            {
                setView.SetLeaderboardSets(leaderboardSets);
            }
        });
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
        // TimeScope - the timerange of the leaderboard you're interested in (daily,weekly,all-time,etc)
        
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

    private void SubmitScore(GKLeaderboard leaderboard, long score)
    {
        Debug.Log("submit score to leaderboard");
        
        // GKLeaderboard.SubmitScore(
        //     100,
        //     0, 
        //     GKLocalPlayer.LocalPlayer,
        //     new []{"classic"}, 
        //     (error) =>
        //     {
        //         Debug.Log("submitted score to classic leaderboard");
        //         if (error != null)
        //             LogNSError(error);
        //     });
        
        leaderboard.SubmitScore(100, 0, GKLocalPlayer.LocalPlayer, (error) =>
        {
            if(error != null)
                LogNSError(error);
        });
    }

    private void LoadEntries(GKLeaderboard leaderboard)
    {
        leaderboard.LoadEntriesForPlayers(
            new []{GKLocalPlayer.LocalPlayer}, 
            GKLeaderboardTimeScope.Today, 
            (playersEntry, entries, error) =>
            {
                if (error != null)
                {
                    LogNSError(error);
                    return;
                }
                Debug.Log($"{leaderboard.BaseLeaderboardID}: local player score: {playersEntry.Score}");
            });
    }
}