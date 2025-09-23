using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private RawImage RawImage;
    [SerializeField] private Image PriceTag;
    [SerializeField] private TextMeshProUGUI PriceText;
    [SerializeField] private Image CheckBox;
    [SerializeField] private Image CheckMark;

    public void Setup(CharacterSO character, bool isOwned, bool isSelected)
    {
        characterName.text = character.characterName;
        CheckBox.gameObject.SetActive(isOwned);
        PriceTag.gameObject.SetActive(!isOwned);
        PriceText.text = $"x{character.price}";
        CheckMark.gameObject.SetActive(isSelected);
        RawImage.texture = character.renderTexture;
    }
    public void BuyAndSelect()
    {
        PriceTag.gameObject.SetActive(false);
        CheckBox.gameObject.SetActive(true);
        ToggleSelect(true);
    }
    public void ToggleSelect(bool select)
    {
        CheckMark.gameObject.SetActive(select);
    }
}
