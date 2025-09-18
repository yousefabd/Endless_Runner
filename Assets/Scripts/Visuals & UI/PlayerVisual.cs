using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player.OnJump += Player_OnJump;
        player.OnMove += Player_OnMove;
        player.OnDuck += Player_OnDuck;
    }

    private void Player_OnJump()
    {
        animator.SetTrigger("Jump");
    }
    private void Player_OnMove(float direction)
    {
        if (!player.IsOnGround())
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
}
