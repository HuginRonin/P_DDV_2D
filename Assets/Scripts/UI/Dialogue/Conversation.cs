using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Conversation", menuName = "Dialogue/Conversation", order = 1)]
public class Conversation : ScriptableObject
{
    public string CharacterNameKey;
    public DialogueNode StartNode;

    public TMP_FontAsset font;
    public Sprite dialoguepanel;
    public Sprite dialoguebuttons;
}
