using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class HealthSystem : MonoBehaviour
{
    public static HealthSystem Instance { get; private set; }
    private int lives = 3;

    public event Action OnGameOver;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Player.Instance.OnTakeDamage += Player_OnTakeDamage;
    }
    private void Player_OnTakeDamage()
    {
        lives--;
        if (lives <= 0)
        {
            OnGameOver?.Invoke();
        }
    }
}
