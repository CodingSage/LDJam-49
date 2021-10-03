using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemyController : EnemyController
{
    public List<Vector3> patrolPoints;
    private int moveToIndex;
    public float pointReachedMaxDistance = 1f;

    public override void Start()
    {
        base.Start();
        moveToIndex = 0;
        if(patrolPoints.Count < 2)
        {
            throw new MissingComponentException("Patrol enemy doesn't have patrol points");
        }
    }

    public override void Tick()
    {
        base.Tick();
        Vector3 moveToPosition = patrolPoints[moveToIndex];
        MoveTowardsPoint(moveToPosition);
        if (GetIsWithinDistance(pointReachedMaxDistance, moveToPosition))
        {
            moveToIndex = moveToIndex >= patrolPoints.Count - 1 ? 0 : moveToIndex + 1;
        }
    }

    public void OnDrawGizmos()
    {
        foreach (Vector3 patrolPoint in patrolPoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(patrolPoint, pointReachedMaxDistance);
        }
    }
}
