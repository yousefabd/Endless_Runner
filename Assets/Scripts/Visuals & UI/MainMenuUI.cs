using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance { get; private set; }
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SelectCharacterButton;
    [SerializeField] private Button QuitButton;

    public event Action OnSelectCharacterPressed;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayButton.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.Game);
        });
        SelectCharacterButton.onClick.AddListener(() => OnSelectCharacterPressed?.Invoke());
        QuitButton.onClick.AddListener(() => Application.Quit());
    }
}
