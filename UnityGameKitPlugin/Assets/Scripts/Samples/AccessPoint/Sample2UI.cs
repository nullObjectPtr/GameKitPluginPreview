using System;
using System.Collections.Generic;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sample2UI : MonoBehaviour
{
    public Button ShowDashboardButton;
    public Toggle ToggleAccessPointButton;

    public Action<bool> OnToggleAccessPoint;
    public Action<GKAccessPointLocation> OnChangeAccessPointLocation;
    public Action<GKGameCenterViewControllerState> OnShowDashboard;

    public TMP_Dropdown AccessPointLocationDropdown;
    public TMP_Dropdown ViewStateDropdown;

    public bool interactable
    {
        set
        {
            ShowDashboardButton.interactable = value;
            ToggleAccessPointButton.interactable = value;
            ViewStateDropdown.interactable = value;
            AccessPointLocationDropdown.interactable = value;
        }
    }

    void Awake()
    {
        //interactable = false;
    }

    void Start()
    {
        // make a dropdown of all the possible values of GKGameCenterViewControllerState
        var viewStateOptions = new List<TMP_Dropdown.OptionData>();
        foreach(var enumValue in Enum.GetValues(typeof(GKGameCenterViewControllerState)))
        {
            viewStateOptions.Add(new TMP_Dropdown.OptionData(enumValue.ToString()));
        }
        ViewStateDropdown.options = viewStateOptions;
        
        // make a dropdown of all the possible access point locations
        var locationOptions = new List<TMP_Dropdown.OptionData>();
        foreach (var enumValue in Enum.GetValues(typeof(GKAccessPointLocation)))
        {
            locationOptions.Add(new TMP_Dropdown.OptionData(enumValue.ToString()));
        }

        AccessPointLocationDropdown.options = locationOptions;
        
        // When the location dropdown is changed, invoke the action with the current value of the location dropdown
        AccessPointLocationDropdown.onValueChanged.AddListener(
            (val) => OnChangeAccessPointLocation?.Invoke((GKAccessPointLocation) val));

        // When the toggle is pressed, invoke the toggle access point action with the current value of the toggle
        ToggleAccessPointButton.onValueChanged.AddListener(
            (val) => OnToggleAccessPoint?.Invoke(val));
        
        // When the show dashboard button is pressed, invoke the show dashboard action with the current value of the
        // view state dropdown
        ShowDashboardButton.onClick.AddListener(
            () => OnShowDashboard?.Invoke((GKGameCenterViewControllerState)ViewStateDropdown.value));
    }
}
