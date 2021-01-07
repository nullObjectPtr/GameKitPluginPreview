using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryView : MonoBehaviour
{
    public TMP_Text PlayerNameTextMesh;
    public TMP_Text PlayerScoreTextMesh;
    public Image background;

    public Color highlightedColor;
    public Color defaultColor;
    
    public string Score
    {
        set => PlayerScoreTextMesh.text = value;
    }

    public string Name
    {
        set => PlayerNameTextMesh.text = value;
    }

    public bool Highlight
    {
        set => background.color = value ? highlightedColor : defaultColor;
    }
}
