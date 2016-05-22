using UnityEngine.Networking;

public class ChatNetworkMessage
{
    private NetworkIdentity networkIdentity;
    private string content;

    public NetworkIdentity NetworkIdentity { get { return networkIdentity; } }
    public string Content { get { return content; } }

    public ChatNetworkMessage(NetworkIdentity pIdentity, string pContent)
    {
        networkIdentity = pIdentity;
        content = pContent;
    }

    public override string ToString()
    {
        return networkIdentity.netId.ToString() + ": " + content;
    }
}
