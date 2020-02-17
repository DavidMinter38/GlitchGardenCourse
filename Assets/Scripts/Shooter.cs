using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    [SerializeField]
    GameObject gun;

    AttackerSpawner myLaneSpawner;

    float gap = 0.2f;

    void Start()
    {
        SetLaneSpawner();
    }

    void Update()
    {
        if(IsAttackerInLane())
        {
            Debug.Log("Shoot");
        }
        else
        {
            Debug.Log("Idle");
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.RoundToInt(Mathf.Abs(spawner.transform.position.y - gap - transform.position.y)) <= Mathf.Epsilon);
            if(isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }

}
