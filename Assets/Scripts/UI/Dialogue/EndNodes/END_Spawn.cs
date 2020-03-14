using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn", menuName = "Dialogue/EndNode/Spawn", order = 5)]
public class END_Spawn : EndNode
{
    public float x;
    public float y;
    public float z;
    public GameObject spawn;
    private Vector3 t;

    public override void OnChosen(GameObject npc)
    {
        base.OnChosen(npc);
        t = new Vector3(x, y, z);

        Instantiate(spawn, t, Quaternion.identity);
    }
}
