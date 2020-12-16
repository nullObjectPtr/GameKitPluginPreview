using System;
using System.Collections.Generic;
using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;
using Random = System.Random;

public class Sample3_Achievements : AbstractSample
{
    private Dictionary<string, GKAchievement> _achievementProgress = new Dictionary<string, GKAchievement>();
    private GKAchievementDescription[] _achievementDescriptions;
    
    protected override void OnAuthenticated()
    {
        Debug.Log("player authenticated");
        
        //1. Load Achievement Descriptions
        //2. Load Local Player's achievement progress
        //3. Award achievements
        LoadAchievementDescriptions();
    }

    public void IssueChallenge(string identifier)
    {
        Debug.Log($"attempting to issue challenge for achievement {identifier}");
        var achievement = GetAchievementProgress(identifier);

        Debug.Log("loading challengeable players from friends list");
        GKLocalPlayer.LocalPlayer.LoadChallengableFriendsWithCompletionHandler((players, error) =>
        {
            Debug.Log("Got challengeable friends");
            if (error != null)
            {
                LogNSError(error);
                return;
            }

            Debug.Log($"local player has {players.Length} changeable friends");
            
            // some subset of these players may not be able to do this challenge?
            // don't really understand this API method, but it's here if you wanna use it!
            achievement.SelectChallengeablePlayers(
                players, 
                (playersWhoCanCompleteChallenge, error2) =>
                {
                    if (error != null)
                        LogNSError(error);
                });
            
            // Your whole friends list will show up, but only the friends in the player's array will be selected by
            // default when the view shows
            
            // pick a single random player to select, as a 1 element array
            var friend = players.Length > 0 
                ? new []{ players[UnityEngine.Random.Range(0, players.Length)] } 
                : new GKPlayer[0];
            
            var viewController = achievement.ChallengeComposeControllerWithMessage("Catch the virus!", friend, (controller, b, sentToPlayerIds) =>
            {
                Debug.Log($"challenge was sent? {(b ? "YES" : "NO")}");
                Debug.Log($"sent to the following player ids: {string.Join(",", sentToPlayerIds)}");
                controller.Dismiss();
            });
            
            viewController.Present();
        });
    }

    // The first step is to load up the achievement descriptions. All achievements need to be pre-registered with
    // App Store Connect so this can be our single source of truth for what a valid/invalid achievement ID is. We
    // can use this to ensure that the local player has a complete set of achievement progress at all times
    public void LoadAchievementDescriptions()
    {
        Debug.Log("loading achievement descriptions");
        GKAchievementDescription.LoadAchievementDescriptionsWithCompletionHandler((descriptions, error) =>
        {
            Debug.Log("Load Achievement Descriptions Handler Called");
            // Can't grab descriptions, can't continue
            if (error != null)
            {
                LogNSError(error);
                return;
            }

            _achievementDescriptions = descriptions ?? new GKAchievementDescription[0];

            Debug.Log($"loaded {_achievementDescriptions.Length} achievement descriptions");
            foreach (var description in _achievementDescriptions)
            {
                Debug.Log($"{description.Identifier}\n{description.Title}\n{description.UnachievedDescription}");
            }

            LoadAchievementProgress();
        });
    }

    public void LoadAchievementProgress()
    {
        // This only grabs achievements that have already been submitted by the local player
        // if you haven't submitted an achievement yet, you will get nothing from this callback
        Debug.Log("Loading achievements");
        GKAchievement.LoadAchievementsWithCompletionHandler((achievements, error) =>
        {
            // You may still have achievements that load even if you get an error, so we let this fall-through for
            // the sample. I'd probably throw an exception here in a real game :-)
            if (error != null)
                LogNSError(error);
            
            // Achievements will be null, if you have not reported any progress for the current player yet
            if (achievements != null)
            {
                // Store each achievement in an dictionary keyed by the achievement index
                foreach (var achievement in achievements)
                {
                    Debug.Log(
                        $"{achievement.Identifier} percent complete: {achievement.PercentComplete} date: {achievement.LastReportedDate}");
                    _achievementProgress[achievement.Identifier] = achievement;
                }
            }

            
            Debug.Log($"loaded progress for {_achievementProgress.Count} achievements");
            IssueChallenge("catch_the_virus");
            AwardAchievement("run_sample_2", true );
        });
    }

    // Grab or make an achievement, set it to complete
    private void AwardAchievement(string identifier, bool showBanner)
    {
        // Overwrite the show banner boolean, don't know why this isn't part of the achievement description instead
        var achievement = GetAchievementProgress(identifier);

        achievement.PercentComplete = 100;
        achievement.ShowsCompletionBanner = showBanner;
        
        // Report the progress
        GKAchievement.ReportAchievements(new []{ achievement }, DefaultCompletionHandler);
    }

    // Grab or make an achievement, update it's progress
    private void AddAchievementProgress(string identifier, int percentProgress, bool showBanner)
    {
        var achievement = GetAchievementProgress(identifier);

        achievement.PercentComplete = Math.Min(achievement.PercentComplete + percentProgress, 100);
        achievement.ShowsCompletionBanner = showBanner;

        // Might not be complete, but still need to save progress
        GKAchievement.ReportAchievements(new[] {achievement}, DefaultCompletionHandler);
    }
    
    private GKAchievement GetAchievementProgress(string identifier)
    {
        // Make sure the achievement we want to report progress for actually exists in Game Center
        var achievementDesc = _achievementDescriptions.FirstOrDefault(a => a.Identifier == identifier);
        if(achievementDesc == null)
            throw new ArgumentException($"there is no achievement with the id {identifier} registered with gamekit");
        
        // If we already have achievement progress for this...use that instance to award this achievement
        // If not, make a new instance from scratch and register it with the dictionary
        if (_achievementProgress.TryGetValue(identifier, out var achievement) == false)
        {
            achievement = new GKAchievement(identifier);
            _achievementProgress[identifier] = achievement;
        }

        return achievement;
    }
    
    // Get an achievement that you can award to some (other) player.
    // This implementation of them does not track progress, consider these achievements boolean only ones beceause this
    // method will create the achievement instance from scratch. You will have to come up with your own solution for
    // awarding achievements to other players that have incremental progress
    
    private GKAchievement MakeAchievementForPlayer(string identifier, GKPlayer player)
    {
        // Make sure this is being used in the way we intend it to be
        if(player == GKLocalPlayer.LocalPlayer)
            throw new InvalidOperationException("GetAchievementForPlayer cannot be used on the local player");
        
        // Make sure the achievement we want to report progress for actually exists in Game Center
        var achievementDesc = _achievementDescriptions.FirstOrDefault(a => a.Identifier == identifier);
        if(achievementDesc == null)
            throw new ArgumentException($"there is no achievement with the id {identifier} registered with gamekit");
        
        if(player == null)
            throw new ArgumentNullException(nameof(player));
        
        return new GKAchievement(identifier, player);
    }
}

