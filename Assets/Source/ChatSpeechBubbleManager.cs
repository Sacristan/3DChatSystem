using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatSpeechBubbleManager : MonoBehaviour
{
    [SerializeField]
    private Text speechBubbleText;
    [SerializeField]
    private float disappearTime = 5f;

    public void PushText(string text)
    {
        StopAllCoroutines();
        StartCoroutine(AddText(text));
    }

    private IEnumerator AddText(string text)
    {
        speechBubbleText.text = text;
        yield return new WaitForSeconds(disappearTime);
        speechBubbleText.text = "";
    }

}
