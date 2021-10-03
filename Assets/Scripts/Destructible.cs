using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{

    public int maxHitPoints = 5;
    public int hitPoints;

    private Animator animator;

    void Start()
    {
        hitPoints = maxHitPoints;
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int hits)
    {
        ModifyHitPoints(-hits);
    }

    public void Heal(int points)
    {
        ModifyHitPoints(points);
    }

    private void ModifyHitPoints(int diff)
    {
        hitPoints += diff;
        hitPoints = Mathf.Min(maxHitPoints, hitPoints);
        if(hitPoints < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool(AnimatorConstants.GAME_OVER, true);
    }
}
