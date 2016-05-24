using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkManager))]
public class ChatManager : MonoBehaviour
{
    private static ChatManager instance;
    private List<ChatNetworkMessage> messages = new List<ChatNetworkMessage>();
    [SerializeField]
    private int messageArrayLimit = 10;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static void PushMessage(NetworkIdentity networkIdentity, string message)
    {
        HandleChatLimits();
        instance.messages.Add(new ChatNetworkMessage(networkIdentity, message));
    }

    void OnGUI()
    {
        GUILayout.Space(200);

        GUILayout.Box("Messages:");

        foreach (ChatNetworkMessage message in messages)
        {
            GUILayout.Box(message.ToString());
        }
    }

    private static void HandleChatLimits()
    {
        if (instance.messages.Count >= instance.messageArrayLimit)
        {
            instance.messages.RemoveAt(0);
        }
    }
}
