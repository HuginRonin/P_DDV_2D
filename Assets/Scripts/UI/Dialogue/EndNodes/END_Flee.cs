using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flee", menuName = "Dialogue/EndNode/Flee", order = 2)]
public class END_Flee : EndNode
{
    public override void OnChosen(GameObject npc)
    {
        base.OnChosen(npc);
        npc.GetComponent<NPCMovementController>().Flee();
    }
}
