using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActionResponse : MonoBehaviour
{
    public event Action<AbilityDefinitionSO> OnActionButtonClicked;

    public AbilityDefinitionSO AbilityData { get; private set; }

    public void InitializeAbility(AbilityDefinitionSO ability)
    {
        AbilityData = ability;
    }

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClickedHandler);
    }

    private void ButtonClickedHandler()
    {
        Debug.Log("ActionResponse class activated.");
        OnActionButtonClicked?.Invoke(AbilityData);
    }
}