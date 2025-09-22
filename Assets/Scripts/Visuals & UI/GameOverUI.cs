using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private TextMeshProUGUI collectiblesText;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        RestartButton.onClick.AddListener(GameManager.Instance.RestartGame);
        gameObject.SetActive(false);
    }
    private void GameManager_OnGameOver()
    {
        collectiblesText.text = (ScoreSystem.Instance.GetCollectibles() * 10).ToString();
        distanceText.text = ScoreSystem.Instance.GetDistance().ToString();
        finalScoreText.text = ScoreSystem.Instance.GetMaxScore().ToString();
        gameObject.SetActive(true);
    }
}
