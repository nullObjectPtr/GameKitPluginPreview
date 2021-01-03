using System;
using System.Collections;
using System.Collections.Generic;
using HovelHouse.GameKit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RealTimeChatView : MonoBehaviour
{
    public TMP_InputField ChatMessageInput;

    public GameObject ChatLinePrefab;
    public Transform ChatLineParent;
    
    public Button SendButton;
    public Button CloseButton;

    public Action<string> OnSendMessage;
    public Action OnCloseClick;
    public Action<GKPlayer,string> OnSendMessageToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        SendButton.onClick.AddListener(OnSendClick);
        CloseButton.onClick.AddListener(() => OnCloseClick?.Invoke());
    }

    private void OnSendClick()
    {
        GKPlayer player = null;
        var msg = ChatMessageInput.text;
        
        if (string.IsNullOrEmpty(msg))
            return;

        ChatMessageInput.text = "";
        
        if (player != null)
            OnSendMessageToPlayer?.Invoke(player, msg);
        else
            OnSendMessage?.Invoke(msg);
    }

    public void AddMessage(string msg)
    {
        var line = Instantiate(ChatLinePrefab, ChatLineParent);
        var text = line.GetComponentInChildren<TMP_Text>();
        text.text = msg;
    }
}
