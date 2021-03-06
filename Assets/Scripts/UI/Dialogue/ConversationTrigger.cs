﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation DialogueData;
    public LayerMask player;
    public GameObject bubble;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == player.value)
        {
            StartDialogue();
            bubble.SetActive(true);
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == player.value)
        {
            EndDialogue();
            bubble.SetActive(false);
        }
    }

    private void EndDialogue()
    {
        DialogueManager.HideDialogue();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogue(DialogueData, gameObject);
    }
}
