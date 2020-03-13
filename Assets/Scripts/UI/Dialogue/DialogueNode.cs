using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Node", order = 2)]
public class DialogueNode : ScriptableObject
{
    public List<DialogueOption> options;
    public string SpeechKey;
}
