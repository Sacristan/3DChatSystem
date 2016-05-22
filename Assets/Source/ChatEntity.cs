using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkIdentity))]
public class ChatEntity : NetworkBehaviour
{
    string message;
    int wordLimit=50;

    private NetworkIdentity networkIdentity;
    
    void Start()
    {
        networkIdentity = GetComponent<NetworkIdentity>();
    }

    [Command]
    void CmdSendMessageToServer(string words)
    {
        RpcSentMessageToClients(words);
    }

    [ClientRpc]
    void RpcSentMessageToClients(string words)
    {
        ChatManager.PushMessage(words);
    }

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            GUILayout.Space(150);
            message = GUILayout.TextArea(message, wordLimit);
            if (GUILayout.Button("Send"))
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
    }

}
