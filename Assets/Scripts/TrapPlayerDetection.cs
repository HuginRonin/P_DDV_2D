using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlayerDetection : PlayerDetection
{
    private Animator ator;
    
    // Start is called before the first frame update
    void Start()
    {
        ator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Warning();
    }

    private void Warning()
    {
        if(DetectPlayer().Length > 0)
        {
            ator.SetBool("Range", true);
        }
        else
        {
            ator.SetBool("Range", false);
            ator.SetBool("Attack", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ator.SetBool("Attack", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ator.SetBool("Attack", false);
    }
}
