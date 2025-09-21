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
