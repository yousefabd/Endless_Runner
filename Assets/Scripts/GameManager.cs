using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action OnGameOver;
    public event Action OnRestart;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HealthSystem.Instance.OnGameOver += HealthSystem_OnGameOver;
    }
    private void HealthSystem_OnGameOver()
    {
        OnGameOver?.Invoke();   
    }
    public void RestartGame()
    {
        OnRestart?.Invoke();
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
}
