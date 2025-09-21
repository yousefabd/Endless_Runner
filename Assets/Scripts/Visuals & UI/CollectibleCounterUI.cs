using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectibleCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleCounterText;
    private void Start()
    {
        ScoreSystem.Instance.OnCollectibleChanged += UpdateCounter;
        UpdateCounter();
    }
    private void UpdateCounter()
    {
        collectibleCounterText.text = ScoreSystem.Instance.GetCollectibles().ToString();
    }
}
