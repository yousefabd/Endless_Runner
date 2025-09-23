using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameOver = false;
    public event Action OnGameOver;
    public event Action OnRestart;
    //public event Action OnPlayerReady;
    private void Awake()
    {
        Instance = this;
        SpawnCharacter();
    }
    private void HealthSystem_OnGameOver()
    {
        OnGameOver?.Invoke();
        isGameOver = true;
    }
    private void SpawnCharacter()
    {
        CharacterSO character = CharacterSelector.GetSelectedCharacter();
        Instantiate(character.prefab, GameSettings.Instance.GetPlayerSpawnOffset(), Quaternion.identity);
        HealthSystem.Instance.OnDeath += HealthSystem_OnGameOver;
    }

    public void RestartGame()
    {
        OnRestart?.Invoke();
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    
}
