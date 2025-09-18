using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody rigidBody;
    [SerializeField] private float laneMoveSpeed = 10f;
    private bool isOnGround = true;
    private int targetLaneIndex;
    public event Action OnJump;
    public event Action<float> OnMove;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        GameInput.Instance.OnHorizontalMove += GameInput_OnHorizontalMove;
        targetLaneIndex = GetLaneIndex(transform.position.x / GameSettings.Instance.GetLaneWidth());
    }
    private void Update()
    {
        HandleJumping();
        HandleMovement();
    }

    private void GameInput_OnHorizontalMove(float direction)
    {
        targetLaneIndex += (int)direction;
        if (Mathf.Abs(targetLaneIndex) > 1)
        {
            targetLaneIndex -= (int)direction;
            // Out of bounds movement
            return;
        }
        OnMove?.Invoke(direction);

    }

    private void HandleMovement()
    {
        if (Mathf.Abs(transform.position.x - GetLanePositionX(targetLaneIndex)) > 0.01f)
        {
            Vector3 targetPosition = new Vector3(GetLanePositionX(targetLaneIndex), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, laneMoveSpeed * Time.deltaTime);
        }
    }

    private void HandleJumping()
    {
        if (GameInput.Instance.IsJumping() && isOnGround)
        {
            float jumpForce = GameSettings.Instance.GetJumpForce();
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            OnJump?.Invoke();
        }
    }
    private int GetLaneIndex(float xPosition)
    {
        float laneWidth = GameSettings.Instance.GetLaneWidth();
        return Mathf.RoundToInt(xPosition / laneWidth);
    }
    private float GetLanePositionX(int laneIndex)
    {
        float laneWidth = GameSettings.Instance.GetLaneWidth();
        return laneIndex * laneWidth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Floor))
        {
            isOnGround = true;
        }
    }
    public bool IsOnGround()
    {
        return isOnGround;
    }
}
