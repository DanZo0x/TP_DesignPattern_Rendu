using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BoxCollider attackHitbox;
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerMovement playerMovement;
    
    [Space]
    [Header("Booleans")]
    [SerializeField] private bool bIsAttacking = false;
    
    private void Awake()
    {
        attackHitbox.enabled = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement.MovementVector2D = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        
        anim.SetTrigger("Attack");
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        bIsAttacking = true;
        attackHitbox.enabled = true;
        yield return new WaitForSeconds(1f);
        bIsAttacking = false;
        attackHitbox.enabled = false;
    }
}
