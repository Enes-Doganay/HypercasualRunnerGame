using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    Animator animator;
    CharacterController characterController;
    private void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponentInParent<Animator>();
        characterController = GetComponentInParent<CharacterController>();
    }
    public void DeactivateRagdoll()
    {
        foreach (var rigidbody in rigidbodies)
            rigidbody.isKinematic = true;
        animator.enabled = true;
    }
    public void ActivateRagdoll()
    {
        foreach (var rigidbody in rigidbodies)
            rigidbody.isKinematic = false;
        animator.enabled=false;
        characterController.enabled = false;
    }
}
