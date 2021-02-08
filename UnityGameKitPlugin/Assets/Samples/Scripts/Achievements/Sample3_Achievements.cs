using System;
using System.Collections.Generic;
using System.Linq;
using HovelHouse.GameKit;
using UnityEngine;

public class Sample3_Achievements : AbstractSample
{
    public AchievementsSampleUI UI;
    
    private Dictionary<string, GKAchievement> _achievementProgress = new Dictionary<string, GKAchievement>();
    private List<GKAchievementDescription> _achievementDescriptions;
    
    protected override void Run()
    {
        // Once we load achievement data, and the UI is drawn, this callback handles toggling the achievement earned
        // status for the player
        UI.OnToggleAchievementEarned = OnToggleAchievement;
        UI.OnChallenge = IssueChallenge;
        
        //1. Load Achievement Descriptions
        //2. Load Local Player's achievement progress
        //3. Award achievements
        LoadAchievementDescriptions();
    }

    public void IssueChallenge(GKAchievement achievement)
    {
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

            Debug.Log($"loaded {descriptions?.Length} achievement descriptions");
            _achievementDescriptions = descriptions != null ? descriptions.ToList() : new List<GKAchievementDescription>();

            // Next - load the users achievement progress
            // This only grabs achievements that have already been submitted by the local player
            LoadAchievementProgress();
        });
    }

    public void LoadAchievementProgress()
    {
        Debug.Log("Loading achievements");
        
        // if you haven't submitted any achievement progress for the current player yet, you will get nothing from this callback
        GKAchievement.LoadAchievementsWithCompletionHandler((achievements, error) =>
        {
            // You may still have achievements that load even if you get an error, so we let this fall-through for
            // the sample. I'd probably throw an exception here in a real game :-)
            if (error != null)
                LogNSError(error);
            
            // Achievements will be null, if you have not reported any progress for the current player yet
            if (achievements != null)
            {
                Debug.Log($"loaded progress for {achievements.Length} achievements");

                // Store each achievement in an dictionary keyed by the achievement index
                foreach (var achievement in achievements)
                {
                    Debug.Log(
                        $"{achievement.Identifier} percent complete: {achievement.PercentComplete} date: {achievement.LastReportedDate}");
                    _achievementProgress[achievement.Identifier] = achievement;
                }
            }
            
            // We may not have pulled down any progress for some achievement description
            // Fixup the achievement progress dictionary by creating new progress data for any achievements were missing
            foreach (var description in _achievementDescriptions)
            {
                var id = description.Identifier;
                if(_achievementProgress.ContainsKey(id) == false)
                    _achievementProgress[id] = new GKAchievement(id);
            }

            PopulateUI();
        });
    }

    private void PopulateUI()
    {
        // Make a new array that contains the progress data in the same order of the descriptions
        var inOrderProgress = new List<GKAchievement>();
        foreach (var description in _achievementDescriptions)
        {
            inOrderProgress.Add(_achievementProgress[description.Identifier]);
        }
        
        UI.SetData(_achievementDescriptions, inOrderProgress);
    }

    private void OnToggleAchievement(GKAchievement achievement, bool isEarned)
    {
        // You complete achievements by setting the PercentComplete property to 100
        // the "complete" property on this object is actually read-only
        var currentlyEarned = achievement.PercentComplete == 100;
        
        // Check for change to prevent inf-loop on UI toggle
        if (currentlyEarned == isEarned)
            return;
        
        achievement.PercentComplete = isEarned ? 100 : 0;
        
        // Overwrite the show banner boolean, don't know why this isn't part of the achievement description instead
        achievement.ShowsCompletionBanner = true;
        
        // Report the progress to the server
        GKAchievement.ReportAchievements(new []{ achievement }, (error) =>
        {
            if(error != null)
            {
                LogNSError(error);
            }
            else
            {
                Debug.Log("Reported achievement for current player");
            }

            UI.RefreshAchievementView(achievement);
        });
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

