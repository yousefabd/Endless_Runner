using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystemUI : MonoBehaviour
{
    public static ShopSystemUI Instance { get; private set; }
    [SerializeField] private CharacterCardUI characterCardTemplate;
    [SerializeField] private Transform charactersGrid;
    [SerializeField] private TextMeshProUGUI collectiblesText;
    [SerializeField] private Button backButton;
    private List<CharacterCardUI> characterCards;

    public event Action<CharacterSO> OnSelectCharacter;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetupCharacterCards();
        collectiblesText.text = $"x{PlayerPrefs.GetInt(nameof(Collectible), 0)}";
        MainMenuUI.Instance.OnSelectCharacterPressed += MainMenuUI_OnSelectCharacterPressed;
        backButton.onClick.AddListener(() => gameObject.SetActive(false));
        gameObject.SetActive(false);
    }
    private void SetupCharacterCards()
    {
        CharactersListSO charactersSOList = Resources.Load<CharactersListSO>(nameof(CharactersListSO));
        List<CharacterSO> charactersList = charactersSOList.list.OrderBy(c => c.characterIndex).ToList();
        characterCards = new List<CharacterCardUI>();
        characterCardTemplate.gameObject.SetActive(false);
        foreach (CharacterSO character in charactersList)
        {
            Transform cardTransform = Instantiate(characterCardTemplate.transform, charactersGrid);
            cardTransform.gameObject.SetActive(true);
            CharacterCardUI card = cardTransform.GetComponent<CharacterCardUI>();
            bool isOwned = ShopSystem.Instance.IsOwned(character);
            bool isSelected = character.Equals(CharacterSelector.GetSelectedCharacter());
            card.Setup(character, isOwned, isSelected);
            card.GetComponent<Button>().onClick.AddListener(() =>
            {
                CharacterCard_OnPressed(card, character);
            });
            characterCards.Add(card);
        }
    }
    private void MainMenuUI_OnSelectCharacterPressed()
    {
        gameObject.SetActive(true);
    }
    private void CharacterCard_OnPressed(CharacterCardUI characterCard, CharacterSO character)
    {
        if (ShopSystem.Instance.IsOwned(character))
        {
            CharacterSelector.SelectCharacter(character);
            ClearSelectedCards();
            OnSelectCharacter?.Invoke(character);
            characterCard.ToggleSelect(true);
        }
        else if (ShopSystem.Instance.BuyAndSelectCharacter(character))
        {
            CharacterSelector.SelectCharacter(character);
            ClearSelectedCards();
            OnSelectCharacter?.Invoke(character);
            characterCard.BuyAndSelect();
            collectiblesText.text = $"x{PlayerPrefs.GetInt(nameof(Collectible), 0)}";
        }
    }
    private void ClearSelectedCards()
    {
        foreach (var card in characterCards)
        {
            card.ToggleSelect(false);
        }
    }
}
