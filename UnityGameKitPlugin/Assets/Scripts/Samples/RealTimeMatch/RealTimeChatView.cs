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

    public Button SendButton;

    public Action<string> OnSendMessage;
    public Action<GKPlayer,string> OnSendMessageToPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        SendButton.onClick.AddListener(OnSendClick);
    }

    private void OnSendClick()
    {
        GKPlayer player = null;
        var msg = ChatMessageInput.text;
        if (string.IsNullOrEmpty(msg))
            return;

        if (player != null)
            OnSendMessageToPlayer?.Invoke(player, msg);
        else
            OnSendMessage?.Invoke(msg);
    }
}
