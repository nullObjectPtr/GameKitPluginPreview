using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingView : MonoBehaviour
{
    public Button FindMatchButton;

    public Slider MinPlayersSlider;
    public Slider MaxPlayersSlider;
    public TMP_Text MinPlayersSliderLabel;
    public TMP_Text MaxPlayersSliderLabel;
    
    public Action<int,int> OnFindMatch;

    void Awake()
    {
        FindMatchButton.onClick.AddListener(OnFindMatchClick);
        MinPlayersSlider.onValueChanged.AddListener(OnMinPlayersValueChanged);
        MaxPlayersSlider.onValueChanged.AddListener(OnMaxPlayersValueChanged);
        
        OnMinPlayersValueChanged(MinPlayersSlider.value);
        OnMaxPlayersValueChanged(MaxPlayersSlider.value);
    }

    private void OnMinPlayersValueChanged(float value)
    {
        var minPlayers = (int) value;
        if (minPlayers > MaxPlayersSlider.value)
            MaxPlayersSlider.value = minPlayers;

        MinPlayersSliderLabel.text = $"min players: {minPlayers}";
    }

    private void OnMaxPlayersValueChanged(float value)
    {
        var maxPlayers = (int) value;
        if (maxPlayers < MinPlayersSlider.value)
            MinPlayersSlider.value = maxPlayers;
        
        MaxPlayersSliderLabel.text = $"max players: {maxPlayers}";
    }

    private void OnFindMatchClick()
    { 
        OnFindMatch?.Invoke((int) MinPlayersSlider.value, (int) MaxPlayersSlider.value);
    }
}
