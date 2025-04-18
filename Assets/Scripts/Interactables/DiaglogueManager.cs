using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI References")]
    public GameObject dialoguePanel;
    public TMP_Text dialogueText; 

    [Header("Typewriter Settings")]
    public float typeSpeed = 0.03f;

    [Header("Font Settings")]
    public int defaultFontSize = 170;

    private Queue<Message> messageQueue = new Queue<Message>();
    private HashSet<string> activeSenders = new HashSet<string>();
    private bool isDisplaying = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowMessage(string text, float duration = 2f, string senderID = "", int fontSize = -1)
    {
        if (!string.IsNullOrEmpty(senderID) && activeSenders.Contains(senderID)) return;

        messageQueue.Enqueue(new Message(text, duration, senderID, fontSize));

        if (!isDisplaying)
            StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        while (messageQueue.Count > 0)
        {
            isDisplaying = true;
            Message current = messageQueue.Dequeue();

            if (!string.IsNullOrEmpty(current.senderID))
                activeSenders.Add(current.senderID);

            dialoguePanel.SetActive(true);
            dialogueText.text = "";

            dialogueText.fontSize = current.fontSize > 0 ? current.fontSize : defaultFontSize;

            foreach (char c in current.text)
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typeSpeed);
            }

            yield return new WaitForSeconds(current.duration);

            dialoguePanel.SetActive(false);
            dialogueText.text = "";

            if (!string.IsNullOrEmpty(current.senderID))
                activeSenders.Remove(current.senderID);
        }

        isDisplaying = false;
    }

    public void ForceClear()
    {
        StopAllCoroutines();
        messageQueue.Clear();
        activeSenders.Clear();
        dialogueText.text = "";
        dialoguePanel.SetActive(false);
        isDisplaying = false;
    }

    private class Message
    {
        public string text;
        public float duration;
        public string senderID;
        public int fontSize;

        public Message(string text, float duration, string senderID, int fontSize)
        {
            this.text = text;
            this.duration = duration;
            this.senderID = senderID;
            this.fontSize = fontSize;
        }
    }
}
