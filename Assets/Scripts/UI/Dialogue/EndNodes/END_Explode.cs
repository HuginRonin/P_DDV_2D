using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Explode", menuName = "Dialogue/EndNode/Explode", order = 4)]
public class END_Explode : EndNode
{
    public float dmg;

    public override void OnChosen(GameObject npc)
    {
        base.OnChosen(npc);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().TakeDamage(dmg);
        Destroy(npc);
    }
}
