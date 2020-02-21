using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject theObject = collision.gameObject;
        if (theObject.GetComponent<Attacker>())
        {
            FindObjectOfType<LivesDisplay>().ReduceLives(theObject.GetComponent<Attacker>().GetDamage());
        }
    }
}
