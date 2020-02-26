using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0f, 5f)]
    float currentSpeed = 1f;

    GameObject currentTarget;

    [SerializeField]
    int damage = 1;

    void Awake()
    {
        FindObjectOfType<LevelController>().SpawnAttacker();
    }

    void OnDestroy()
    {
        LevelController controller = FindObjectOfType<LevelController>();
        if(controller != null)
        {
            controller.KillAttacker();
        }
    }


    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
        if(currentSpeed != 0)
        {
            currentSpeed *= 0.8f + (PlayerPrefsController.GetDifficulty() * 0.2f);
        }
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentAttacker(float damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.InflictDamage(damage);
        }
    }

    public int GetDamage()
    {
        return damage;
    }
}
