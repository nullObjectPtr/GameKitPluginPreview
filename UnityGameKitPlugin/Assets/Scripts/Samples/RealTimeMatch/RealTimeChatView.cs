using System;
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
    public Button PrivateMessageButton;
    public PrivateMessageSelectView PrivateMessageSelectView;
    
    public Action<string> OnSendMessage;
    public Action<GKPlayer,string> OnSendMessageToPlayer;
    
    private GKMatch match;
    
    // The player we want to send a chat message to
    // Or null, for the whole room
    private GKPlayer player;

    // Start is called before the first frame update
    void Awake()
    {
        SendButton.onClick.AddListener(OnSendClick);
        PrivateMessageButton.onClick.AddListener(OnPrivateMessageClick);
    }

    private void OnSendClick()
    {
        Debug.Log("OnSendClick");
        var msg = ChatMessageInput.text;
        Debug.Log(msg);
        
        if (string.IsNullOrEmpty(msg))
            return;

        ChatMessageInput.text = "";

        if (player != null)
        {
            OnSendMessageToPlayer?.Invoke(player, msg);
            AddMessage($"(to {player.DisplayName}):{msg}");
        }
        else
        {
            OnSendMessage?.Invoke(msg);
            AddMessage(msg);
        }
    }

    private void OnPrivateMessageClick()
    {
        // make a list of all the player's in the room we can send a private message to
        Debug.Log("OnPrivateMessageClick");
        var players = match.Players;
        PrivateMessageSelectView.Show(players, (player) =>
        {
            this.player = player;
        });
    }

    public void AddMessage(string msg)
    {
        Debug.Log($"Add Message: {msg}");
        var line = Instantiate(ChatLinePrefab, ChatLineParent);
        var text = line.GetComponentInChildren<TMP_Text>();
        text.text = msg;
    }

    public void Show(GKMatch match)
    {
        this.match = match ?? throw new ArgumentNullException(nameof(match));
        
        // Clear out old messages from previous sessions
        for(var i = ChatLineParent.childCount - 1; i >= 0; --i)
            Destroy(ChatLineParent.GetChild(i).gameObject);

        gameObject.SetActive(true);
    }
}
