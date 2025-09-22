using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SelectCharacterButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private CharacterSO testCharacter;

    private void Start()
    {
        PlayButton.onClick.AddListener(() =>
        {
            CharacterSelector.Instance.SelectCharacter(testCharacter);
            SceneLoader.LoadScene(SceneLoader.Scene.Game);
        });
        QuitButton.onClick.AddListener(() =>  Application.Quit());
    }
}
