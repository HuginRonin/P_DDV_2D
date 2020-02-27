using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : PartHealthSystem
{
    GlobalHealthSystem ghs;
    public float ContributionFactor;
    public float HealthContribution => (MaxHealth - CurrentHealth) * ContributionFactor;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount);
        if (!ghs)
        {
            ghs = GetComponentInParent<GlobalHealthSystem>();
        }

        ghs.BodyPartHit();
    }
}
