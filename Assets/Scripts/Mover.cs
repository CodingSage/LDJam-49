using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    private Rigidbody body;

    public float velocity = 1f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void MoveInDirection(Vector3 direction)
    {
        direction = Vector3.Normalize(direction);
        body.velocity = direction * velocity;
    }

    public void Stop()
    {
        body.velocity = Vector3.zero;
    }
}
