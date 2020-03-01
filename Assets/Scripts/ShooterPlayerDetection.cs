using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayerDetection : PlayerDetection
{
    private Animator ator;

    // Start is called before the first frame update
    void Start()
    {
        ator = GetComponent<Animator>();
    }

    void Update()
    {
        Warning();
    }

    private void Warning()
    {
        if (DetectPlayer().Length > 0)
        {
            ator.SetTrigger("Attack");
        }
    }
}
