using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleport", menuName = "Dialogue/EndNode/Teleport", order = 3)]
public class END_Teleport : EndNode
{
    public float x;
    public float y;
    public float z;
    private Transform t;

    public override void OnChosen(GameObject npc)
    {
        base.OnChosen(npc);
        t = npc.transform;
        t.position += new Vector3(x, y, z);
    }

}
