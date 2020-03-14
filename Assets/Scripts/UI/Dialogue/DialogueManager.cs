using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Animator DialogueAnimator;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Speech;
    public TextMeshProUGUI[] OptionTexts;
    public Image dialoguePanel;
    public Image[] dialogueButtons;

    private GameObject _npc;
    private DialogueNode currentNode;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        Instance = this;

        HideDialogue();
    }

    void ShowDialogue()
    {
        DialogueAnimator.SetBool("Show", true);
    }

    public static void HideDialogue()
    {
        Instance._HideDialogue();
    }

    void _HideDialogue()
    {
        DialogueAnimator.SetBool("Show", false);
    }

    public static void StartDialogue(Conversation conversation, GameObject gameObject)
    {
        Instance._StartDialogue(conversation,gameObject);
    }

    private void _StartDialogue(Conversation conversation, GameObject npc)
    {
        _npc = npc;
        currentNode = conversation.StartNode;
        Name.text = Localizator.GetText(conversation.CharacterNameKey);
        SetStyle(conversation);
        SetText(currentNode);

        ShowDialogue();
    }

    private void SetStyle(Conversation conversation)
    {
        Name.font = conversation.font;
        Speech.font = conversation.font;
        foreach(TextMeshProUGUI t in OptionTexts)
        {
            t.font = conversation.font;
        }

        dialoguePanel.sprite = conversation.dialoguepanel;
        foreach(Image i in dialogueButtons)
        {
            i.sprite = conversation.dialoguebuttons;
        }
    }

    private void SetText(DialogueNode currentNode)
    {
        Speech.text = Localizator.GetText(currentNode.SpeechKey);

        for(int i = 0; i < OptionTexts.Length; i++)
        {
            if (i < currentNode.options.Count)
            {
                OptionTexts[i].transform.parent.gameObject.SetActive(true);
                OptionTexts[i].text = Localizator.GetText(currentNode.options[i].KeyOptionText);
            }
            else
            {
                OptionTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void OptionChose(int option)
    {
        currentNode = currentNode.options[option].NextNode;

        if(currentNode is EndNode)
        {
            DoEndNode(currentNode as EndNode);
        }
        else
        {
            SetText(currentNode);
        }
 
    }

    private void DoEndNode(EndNode endNode)
    {
        endNode.OnChosen(_npc);
        HideDialogue();
    }
}
