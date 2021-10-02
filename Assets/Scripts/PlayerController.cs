using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
[RequireComponent(typeof(DrunkBehaviour))]
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

        Vector3 rotation = GetRotationDirection();
        if (rotation != Vector3.zero) 
        {
            rotator.RotateTowardsDirection(rotation + noise);
            // rotation animation
        } 
        else
        {

        }

        Vector3 movement = GetMovement();
        if (movement != Vector3.zero)
        {
            mover.MoveInDirection(movement + noise);
        } 
        else
        {
            mover.Stop();
            animator.SetBool(AnimatorConstants.MOVING_FORWARD_TAG, false);
            animator.SetBool(AnimatorConstants.MOVING_BACKWARD_TAG, false);
        }
    }

    private Vector3 GetMovement()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement = transform.forward;
            animator.SetBool(AnimatorConstants.MOVING_FORWARD_TAG, true);
            animator.SetBool(AnimatorConstants.MOVING_BACKWARD_TAG, false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movement = -transform.forward;
            animator.SetBool(AnimatorConstants.MOVING_FORWARD_TAG, false);
            animator.SetBool(AnimatorConstants.MOVING_BACKWARD_TAG, true);
        }
        return movement;
    }

    private Vector3 GetRotationDirection()
    {
        Vector3 rotation = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            rotation = -transform.right;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation = transform.right;
        }
        return rotation;
    }
}
