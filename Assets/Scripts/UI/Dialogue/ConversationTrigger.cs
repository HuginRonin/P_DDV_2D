using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public Conversation DialogueData;
    public LayerMask player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == player.value)
        {
            StartDialogue();
        }   
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogue(DialogueData, gameObject);
    }
}
