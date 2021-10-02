using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;

    private Vector3 delta;

    void Start()
    {
        delta = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + delta;
    }
}
