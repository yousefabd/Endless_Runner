using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem Instance { get; private set; }
    int maxLives = 3;
    private int lives;

    public event Action OnDeath;
    private void Awake()
    {
        Instance = this;
        lives = maxLives;
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
            OnDeath?.Invoke();
        }
    }
    public int GetMaxLives()
    {
        return maxLives;
    }
}
