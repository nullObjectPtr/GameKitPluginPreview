using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AchievementWidget : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI TitleTextMesh;
    public TextMeshProUGUI DescriptionTextMesh;
    public GameObject Highlight;
    
    public Color UnachievedTextColor;
    public Color AchievedTextColor;

    public GKAchievementDescription description;
    public GKAchievement progress;

    public UnityEvent onClick = new UnityEvent();

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            _isSelected = value;
            Highlight?.SetActive(_isSelected);
        }
    }

    void Awake()
    {
        Refresh();
    }

    public void SetData(GKAchievementDescription description, GKAchievement progress)
    {
        this.description = description;
        this.progress = progress;
        Refresh();
    }

    public void Refresh()
    {
        var isCompleted = progress != null && progress.Completed;
        
        var textColor = isCompleted ? UnachievedTextColor : AchievedTextColor;
        TitleTextMesh.color = textColor;
        DescriptionTextMesh.color = textColor;

        if (description != null)
        {
            TitleTextMesh.text = description.Title;
            DescriptionTextMesh.text =
                isCompleted ? description.AchievedDescription : description.UnachievedDescription;
        }

        if(Highlight != null)
            Highlight.SetActive(IsSelected);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick?.Invoke();
    }
}
