using HovelHouse.GameKit;
using UnityEngine;

public class Sample2_Leaderboards : AbstractSample
{
    private GKLeaderboard[] leaderboards;

    protected override void OnAuthenticated()
    {
        Debug.Log("Player Authenticated");
        RunLeaderboardSample();
    }

    private void RunLeaderboardSample()
    {
        LoadAllLeaderboards();
    }

    private void LoadAllLeaderboards()
    {
        Debug.Log("Loading leaderboards");
        GKLeaderboard.LoadLeaderboardsWithIDs(new []{"recurring","classic"}, (leaderboards, error) =>
        {
            if (error != null)
            {
                LogNSError(error);
                return;
            }
            
            Debug.Log($"retrieved {leaderboards.Length} leaderboards");
            foreach (var leaderboard in leaderboards)
            {
                Debug.Log($"{leaderboard.Title} {leaderboard.Duration}");
            }

            this.leaderboards = leaderboards;

            LoadLeaderboardEntries();
        });
    }

    private void LoadLeaderboardEntries()
    {
        LoadEntries(leaderboards[0]);
        LoadEntries(leaderboards[1]);
        SubmitScore(leaderboards[0], 100);
        SubmitScore(leaderboards[1], 100);
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