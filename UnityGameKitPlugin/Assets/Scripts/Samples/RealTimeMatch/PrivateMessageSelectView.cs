using System;
using System.Collections.Generic;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrivateMessageSelectView : MonoBehaviour
{
    public Button PlayerButtonPrefab;
    public Transform ButtonParent;

    private Action<GKPlayer> OnPlayerSelected;
    
    public void Show(IEnumerable<GKPlayer> matchPlayers, Action<GKPlayer> action)
    {
        Debug.Log("Show");
        
        OnPlayerSelected = action;

        Debug.Log("destroying old buttons");
        // Remove any previous buttons, in case the player's list has changed
        for (var i = ButtonParent.childCount - 1; i >= 0; i--)
        {
            var btn = ButtonParent.GetChild(i).GetComponent<Button>();
            if(btn != null)
                Destroy(btn.gameObject);
        }

        // Create a button for clearing the selection
        var clearButton = Instantiate(PlayerButtonPrefab, ButtonParent);
        clearButton.GetComponentInChildren<TMP_Text>().text = "everyone (clear selection)";
        clearButton.onClick.AddListener(() => OnButtonClick(null));
        
        // Create a new button for each player
        foreach (var player in matchPlayers)
        {
            var btn = Instantiate(PlayerButtonPrefab, ButtonParent);
            var btnLabel = btn.GetComponentInChildren<TMP_Text>();
            btnLabel.text = player.DisplayName;
            btn.onClick.AddListener(() => OnButtonClick(player));
            
            Debug.Log($"Added button for {player.DisplayName}");
        }

        gameObject.SetActive(true);
    }

    private void OnButtonClick(GKPlayer player)
    {
        OnPlayerSelected?.Invoke(player);
        OnPlayerSelected = null;
        gameObject.SetActive(false);
    }
}
