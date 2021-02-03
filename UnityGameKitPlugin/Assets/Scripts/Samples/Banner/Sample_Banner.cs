using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine.UI;

public class Sample_Banner : AbstractSample
{
    public TMP_InputField MessageTextMesh;
    public TMP_InputField TitleTextMesh;
    public Button ShowButton;
    
    public Slider DurationSlider;

    protected override void Run()
    {
        ShowButton.onClick.AddListener(OnShowClick);
    }

    void OnShowClick()
    {
        var duration = DurationSlider.value;
        if(duration > 0)
            GKNotificationBanner.ShowBannerWithTitleAndMessageDuration(
                TitleTextMesh.text,
                MessageTextMesh.text,
                duration,
                OnBannerShown
                );
        else
            GKNotificationBanner.ShowBannerWithTitle(
                TitleTextMesh.text,
                MessageTextMesh.text,
                OnBannerShown);
    }

    void OnBannerShown()
    {
        Debug.Log("The banner is now displayed");
    }
}
