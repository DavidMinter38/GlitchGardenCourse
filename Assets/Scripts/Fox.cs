﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject theObject = collision.gameObject;

        if(theObject.GetComponent<Gravestone>())
        {
            gameObject.GetComponent<Animator>().SetTrigger("JumpTrigger");
        }
        else if (theObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(theObject);
        }
    }
}
