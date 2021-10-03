using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(DrunkBehaviour))]
[RequireComponent(typeof(Destructible))]
public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private Rotator rotator;
    private DrunkBehaviour drunkBehaviour;
    private Animator animator;

    void Start()
    {
        mover = GetComponent<Mover>();
        rotator = GetComponent<Rotator>();
        drunkBehaviour = GetComponent<DrunkBehaviour>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 noise = drunkBehaviour.GetNoisyMovement();

        // -ve - backward ; +ve - forward ; 0 - no movement
        int moving = GetMovement(noise);

        // -ve - left ; +ve - right ; 0 - no rotation
        int rotating = GetRotationDirection();

        Animation(moving, rotating);
    }

    private void Animation(int moving, int rotating)
    {
        animator.SetBool(AnimatorConstants.MOVING_BACKWARD_TAG, moving < 0);
        animator.SetBool(AnimatorConstants.MOVING_FORWARD_TAG, moving > 0);
        animator.SetBool(AnimatorConstants.TURNING, rotating != 0);
        // set mirroring in turning animation depending on rotation direction; default turn is left
        animator.SetBool(AnimatorConstants.TURNING_MIRROR, rotating > 0);
    }

    private int GetMovement(Vector3 noise)
    {
        int moving = 0;
        if (Input.GetKey(KeyCode.W))
        {
            mover.MoveInDirection(transform.forward + noise);
            moving = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moving = -1;
            mover.MoveInDirection(-transform.forward + noise);
        }
        else
        {
            mover.Stop();
        }
        return moving;
    }

    private int GetRotationDirection()
    {
        int rotating = 0;
        if (Input.GetKey(KeyCode.A))
        {
            rotator.RotateTowardsDirection(-transform.right);
            rotating = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotator.RotateTowardsDirection(transform.right);
            rotating = 1;
        }
        return rotating;
    }
}
