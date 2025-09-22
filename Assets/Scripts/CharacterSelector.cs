using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector Instance { get; private set; }
    [SerializeField] private List<CharacterSO> characters;
    private int selectedCharacterIndex = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt(nameof(CharacterSO), 0);
    }

    public CharacterSO GetSelectedCharacter()
    {
        foreach (var chara in characters)
        {
            if (chara.characterIndex == selectedCharacterIndex)
            {
                return chara;
            }
        }
        return characters[0];
    }
    public void SelectCharacter(CharacterSO characterSO)
    {
        selectedCharacterIndex = characterSO.characterIndex;
        PlayerPrefs.SetInt(nameof(CharacterSO), selectedCharacterIndex);
    }
}
