using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }
    private int distance = 0;
    private int collectibles;

    public event Action OnCollectibleChanged;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }
    private void GameManager_OnGameOver()
    {
        int storedCollectibles = PlayerPrefs.GetInt(nameof(Collectible), 0);
        PlayerPrefs.SetInt(nameof(Collectible), storedCollectibles + collectibles);
        Debug.Log(storedCollectibles);
    }
    public void AddCollectible()
    {
        collectibles += 1;
        OnCollectibleChanged?.Invoke();
    }
    public int GetCollectibles()
    {
        return collectibles;
    }
    public void AddDistance()
    {
        distance++;
    }
    public int GetMaxScore()
    {
        return distance + collectibles * 10;
    }
    public int GetDistance()
    {
        return distance;
    }


}
