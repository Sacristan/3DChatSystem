using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class ChatEntity : NetworkBehaviour
{
    string message = "";
    int wordLimit = 50;

    private NetworkIdentity networkIdentity;
    private ChatSpeechBubbleManager chatSpeechBubbleManager;

    void Start()
    {
        networkIdentity = GetComponent<NetworkIdentity>();
        chatSpeechBubbleManager = GetComponent<ChatSpeechBubbleManager>();
    }

    [Command]
    void CmdSendMessageToServer(string message)
    {
        RpcSentMessageToClients(message);
    }

    [ClientRpc]
    void RpcSentMessageToClients(string message)
    {
        ChatManager.PushMessage(networkIdentity, message);
        chatSpeechBubbleManager.PushText(message);
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            GUILayout.Space(150);
            message = GUILayout.TextArea(message, wordLimit);
            if (GUILayout.Button("Send"))
            {
                SendMessage();
            }
        }
    }

    private void SendMessage()
    {
        if (networkIdentity.isServer)
        {
            RpcSentMessageToClients(message);
        }
        else
        {
            CmdSendMessageToServer(message);
        }
    }

}
