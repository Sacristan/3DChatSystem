using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(UnityEngine.Networking.NetworkManager))]
public class ChatManager : MonoBehaviour
{
    private static ChatManager instance;

    private List<string> messages = new List<string>();
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

    public static void PushMessage(string message)
    {
        instance.messages.Add(message);
    }

    void OnGUI()
    {
        GUILayout.Space(200);
        GUILayout.Box("MessageList");

        foreach (string message in messages)
        {
            GUILayout.Box(message);
        }
    }
}
