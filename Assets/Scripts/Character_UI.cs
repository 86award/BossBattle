using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Character_UI : MonoBehaviour
{
    [SerializeField]
    private Character _character;

    [SerializeField]
    private TextMeshProUGUI _nameplate;

    [SerializeField]
    private GameObject _buttonPrefab;

    [SerializeField]
    private GameObject _actionToolbarFrame; // parent of any action buttons

    [SerializeField]
    private List<Button> _actionToolbarButtons;
    // what I really want to do here is only spawn as many buttons as the character has abilities

    private void Awake()
    {
        _character.UpdateNamePlate += UpdateNamePlate;
        _character.CharacterActivated += ShowActionBarButtons;
        _character.PopulateAbilityUI += PopulateAbilities;

        //foreach (Button button in _actionToolbarButtons)
        //{
        //    button.GetComponent<CharacterActionResponse>().AttackButtonClicked += ActionButtonClicked;
        //}

        // as part of initialising I should create a list with # of elements == to number of abilities
        //foreach (AbilityDefinitionSO ability in _character.Abilities) //_actionToolbar.AddComponent<Button>();
        //{
        //    Debug.Log(ability);
        //}
        //foreach (Button button in _actionButtons) button.gameObject.SetActive(false);
    }

    private void PopulateAbilities()
    {
        foreach (AbilityDefinitionSO ability in _character.Abilities)
        {
            // instantiate a button prefab
            GameObject newButton = Instantiate(_buttonPrefab, _actionToolbarFrame.transform);
            Button actionButton = newButton.GetComponent<Button>();
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = ability.AbilityName; // needed to reach into the child and get TMP component
            actionButton.GetComponent<Image>().sprite = ability.AbilityImage;
            _actionToolbarButtons.Add(actionButton);
            CharacterActionResponse actionResponse = actionButton.GetComponent<CharacterActionResponse>();
            actionResponse.InitializeAbility(ability);
            actionResponse.OnActionButtonClicked += ActionButtonHandler;
            actionResponse.OnActionButtonClicked += _character.AbilitySelectedHandler;
        }
        foreach (Button button in _actionToolbarButtons) button.gameObject.SetActive(false);
    }

    private void UpdateNamePlate()
    {
        _nameplate.text = _character.Name;
    }

    private void ShowActionBarButtons()
    {
        foreach (Button button in _actionToolbarButtons) button.gameObject.SetActive(true); // must remember to get the gameObject, not just button component
    }

    private void ActionButtonHandler(AbilityDefinitionSO ability)
    {
        foreach (Button button in _actionToolbarButtons) button.gameObject.SetActive(false);
    }
}
