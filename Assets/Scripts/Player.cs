using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private Collider standCollider;
    [SerializeField] private Collider duckCollider;
    private Rigidbody rigidBody;

    private enum PlayerState
    {
        Standing,
        Ducking
    }
    private PlayerState currentState;
    private bool isOnGround = true;
    private int targetLaneIndex;
    private float duckTimerMax = 0.8f;
    private float duckTimer = 0f;
    private float invincibleTimerMax = 0.8f;
    private float invincibleTimer;
    public event Action OnJump;
    public event Action<float> OnMove;
    public event Action OnDuck;
    public event Action OnTakeDamage;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        StandUp();
        currentState = PlayerState.Standing;
        GameInput.Instance.OnHorizontalMove += GameInput_OnHorizontalMove;
        GameInput.Instance.OnDuck += GameInput_OnDuck;
        targetLaneIndex = GetLaneIndex(transform.position.x / GameSettings.Instance.GetLaneWidth());
    }
    private void Update()
    {
        HandleJumping();
        HandleDucking();
        HandleMovement();
        invincibleTimer -= Time.deltaTime;
    }

    private void GameInput_OnHorizontalMove(float direction)
    {
        targetLaneIndex += (int)direction;
        if (Mathf.Abs(targetLaneIndex) > 1)
        {
            targetLaneIndex -= (int)direction;
            OnTakeDamage?.Invoke();
            return;
        }
        OnMove?.Invoke(direction);
    }
    private void GameInput_OnDuck()
    {
        if (!isOnGround)
        {
            rigidBody.AddForce(Vector3.down * GameSettings.Instance.GetJumpForce(), ForceMode.Impulse);
        }
        Duck();
    }
    private void HandleMovement()
    {
        float lanePositionX = GetLanePositionX(targetLaneIndex);
        if (Mathf.Abs(transform.position.x - lanePositionX) > 0.01f)
        {
            Vector3 targetPosition = new Vector3(lanePositionX, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, GameSettings.Instance.GetLaneMoveSpeed() * Time.deltaTime);
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
    private void HandleDucking()
    {
        switch (currentState)
        {
            case PlayerState.Standing:
                break;
            case PlayerState.Ducking:
                duckTimer -= Time.deltaTime;
                if (duckTimer <= 0f)
                {
                    StandUp();
                }
                break;
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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(TagNames.Obstacle))
        {
            if (invincibleTimer <= 0 && !GameManager.Instance.IsGameOver())
            {
                OnTakeDamage?.Invoke();
            }
            invincibleTimer = invincibleTimerMax;
        }
    }
    public bool IsOnGround()
    {
        return isOnGround;
    }
    public bool IsDucking()
    {
        return currentState == PlayerState.Ducking;
    }
    public void StandUp()
    {
        standCollider.enabled = true;
        duckCollider.enabled = false;
        currentState = PlayerState.Standing;
    }
    public void Duck()
    {
        if (currentState == PlayerState.Ducking) return;

        OnDuck?.Invoke();

        duckCollider.enabled = true;
        standCollider.enabled = false;
        currentState = PlayerState.Ducking;
        duckTimer = duckTimerMax;
    }
}
