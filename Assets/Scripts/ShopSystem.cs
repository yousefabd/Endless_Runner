using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static ShopSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        //default character is already owned
        PlayerPrefs.SetInt(CharacterSelector.GetDefaultCharacter().characterName, 1);
    }

    public bool IsOwned(CharacterSO character)
    {
        int isOwned = PlayerPrefs.GetInt(character.characterName, 0);
        return isOwned == 1;
    }

    public bool BuyAndSelectCharacter(CharacterSO character)
    {
        int storedCollectibles = PlayerPrefs.GetInt(nameof(Collectible), 0);
        if (character.price > storedCollectibles)
            return false;
        storedCollectibles -= character.price;
        PlayerPrefs.SetInt(nameof(Collectible), storedCollectibles);
        PlayerPrefs.SetInt(character.name, 1);
        CharacterSelector.SelectCharacter(character);
        return true;
    }
}
