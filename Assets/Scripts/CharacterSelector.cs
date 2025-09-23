using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CharacterSelector
{
    private static CharactersListSO charactersListSO;
    private static List<CharacterSO> characters {
        get
        {
            if (charactersListSO == null)
            {
                charactersListSO = Resources.Load<CharactersListSO>(nameof(CharactersListSO));
            }
            return charactersListSO.list;
        }
    }
    private static int selectedCharacterIndex = 0;
    public static CharacterSO GetSelectedCharacter()
    {
        selectedCharacterIndex = PlayerPrefs.GetInt(nameof(CharacterSO), 0);
        foreach (var chara in characters)
        {
            if (chara.characterIndex == selectedCharacterIndex)
            {
                return chara;
            }
        }
        return characters[0];
    }
    public static CharacterSO GetDefaultCharacter()
    {
        return characters.Where(c => c.characterIndex == 0).FirstOrDefault();
    }
    public static void SelectCharacter(CharacterSO characterSO)
    {
        selectedCharacterIndex = characterSO.characterIndex;
        PlayerPrefs.SetInt(nameof(CharacterSO), selectedCharacterIndex);
    }
}
