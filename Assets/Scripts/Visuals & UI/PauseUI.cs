using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public static PauseUI Instance { get; private set; }
    [SerializeField] private Button PauseButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PauseButton.onClick.AddListener(() =>
        {
            Pause();
        });
        ResumeButton.onClick.AddListener(() =>
        {
            Resume();
        });
        MainMenuButton.onClick.AddListener(() =>
        {
            Resume();
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        });
        gameObject.SetActive(false);
    }
    private void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
