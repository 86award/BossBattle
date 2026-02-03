using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActionResponse : MonoBehaviour
{
    public event Action<AbilityDefinitionSO> ActionButtonClicked;

    public AbilityDefinitionSO AbilityData { get; private set; }

    public void InitializeAbility(AbilityDefinitionSO ability)
    {
        AbilityData = ability;
    }

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        Debug.Log("ActionResponse class activated.");
        ActionButtonClicked?.Invoke(AbilityData);
    }
}