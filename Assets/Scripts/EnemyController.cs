using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(Destructor))]
public class EnemyController : MonoBehaviour
{

    private Mover mover;
    private Rotator rotator;

    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        Tick();
    }

    public virtual void Tick()
    {
    }

    public virtual void OnExitState()
    {
    }

    protected void MoveTowardsPoint(Vector3 moveTo)
    {
        Vector3 currentPos = transform.position;
        Vector3 newDirection = moveTo - currentPos;
        mover.MoveInDirection(newDirection);
        rotator.RotateTowardsDirection(newDirection);
    }

    protected bool GetIsWithinDistance(float maxDistance, Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;
        return directionToTarget.magnitude < maxDistance;
    }
}
