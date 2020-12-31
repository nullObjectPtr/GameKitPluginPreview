using System;
using System.Collections.Generic;
using HovelHouse.GameKit;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AchievementsSampleUI : MonoBehaviour
{
    public Toggle EarnedToggle;
    public Button ChallengeButton;
    public GameObject AchievementTogglePrefab;
    public GameObject AchievementToggleParent;

    public Action<GKAchievement, bool> OnToggleAchievementEarned;
    public Action<GKAchievement> OnChallenge;
    
    private AchievementWidget selectedAchievementWidget;
    private Dictionary<GKAchievement,AchievementWidget> _achievementWidgets = new Dictionary<GKAchievement, AchievementWidget>();
    

    void Awake()
    {
        EarnedToggle.isOn = false;
        EarnedToggle.onValueChanged.AddListener(OnToggle);
        ChallengeButton.onClick.AddListener(OnChallengeClick);
    }
    public void SetData(List<GKAchievementDescription> descriptions, List<GKAchievement> progresses)
    {
        // Clear out any old UI elements
        _achievementWidgets.Clear();
        for (var i = AchievementToggleParent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(AchievementToggleParent.transform.GetChild(i));
        }
        
        // Make some new ones
        for (var i = 0; i < descriptions.Count; i++)
        {
            var go = Instantiate(AchievementTogglePrefab, AchievementToggleParent.transform);
            var achievementWidget = go.GetComponentInChildren<AchievementWidget>();

            var achievement = progresses[i];
            _achievementWidgets[achievement] = achievementWidget;
            
            achievementWidget.SetData(descriptions[i], achievement);
            achievementWidget.onClick.AddListener(() => SetSelectedAchievement(achievementWidget));
        }
    }

    public void SetSelectedAchievement(AchievementWidget widget)
    {
        // Deselect the achievement if currently selected
        if (selectedAchievementWidget == widget)
            widget = null;
        
        if (selectedAchievementWidget != null)
            selectedAchievementWidget.IsSelected = false;
        
        selectedAchievementWidget = widget;

        if (selectedAchievementWidget != null)
            selectedAchievementWidget.IsSelected = true;

        EarnedToggle.isOn = selectedAchievementWidget != null &&
                            selectedAchievementWidget.progress.PercentComplete == 100;
    }

    private void OnToggle(bool isOn)
    {
        Debug.Log("selected: " + EventSystem.current.currentSelectedGameObject, EventSystem.current.currentSelectedGameObject);
        OnToggleAchievementEarned?.Invoke(selectedAchievementWidget?.progress, isOn);
    }

    private void OnChallengeClick()
    {
        OnChallenge?.Invoke(selectedAchievementWidget?.progress);
    }

    public void RefreshAchievementView(GKAchievement achievement)
    {
        _achievementWidgets[achievement].Refresh();
    }
}
