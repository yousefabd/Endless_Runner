using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        Player.Instance.OnJump += Player_OnJump;
        Player.Instance.OnMove += Player_OnMove;
        Player.Instance.OnDuck += Player_OnDuck;
        Player.Instance.OnTakeDamage += Player_OnTakeDamage;
        HealthSystem.Instance.OnDeath += HealthSystem_OnDeath;
    }

    private void Player_OnJump()
    {
        animator.SetTrigger("Jump");
    }
    private void Player_OnTakeDamage()
    {
        animator.SetTrigger("Trip");
    }
    private void Player_OnMove(float direction)
    {
        if (!Player.Instance.IsOnGround() || Player.Instance.IsDucking())
        {
            return;
        }
        if (direction < 0)
        {
            animator.SetTrigger("TurnLeft");
        }
        else if (direction > 0)
        {
            animator.SetTrigger("TurnRight");
        }
    }
    private void Player_OnDuck()
    {
        animator.SetTrigger("Slide");
    }

    private void HealthSystem_OnDeath()
    {
        animator.SetBool("IsGameOver", true);
        animator.SetTrigger("Fall");
    }
}
