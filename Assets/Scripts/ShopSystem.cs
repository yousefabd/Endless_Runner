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
    }

    public bool IsOwned(CharacterSO character)
    {
        int isOwned = PlayerPrefs.GetInt(character.name, 0);
        return isOwned == 1;
    }

    public bool BuyCharacter(CharacterSO character)
    {
        int storedCollectibles = PlayerPrefs.GetInt(nameof(Collectible), 0);
        if (character.price > storedCollectibles)
            return false;
        storedCollectibles -= character.price;
        PlayerPrefs.SetInt(nameof(Collectible), storedCollectibles);
        PlayerPrefs.SetInt(character.name, 1);
        return true;
    }
}
