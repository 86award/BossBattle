using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character_UI : MonoBehaviour
{
    [SerializeField]
    private Character _character;

    [SerializeField]
    private TextMeshProUGUI _nameplate;

    //[SerializeField]
    //private List<Button> _actionButtons;
    // what I really want to do here is only spawn as many buttons as the character has abilities

    private void Awake()
    {
        _character.UpdateNamePlate += UpdateNamePlate;
    }

    private void UpdateNamePlate()
    {
        _nameplate.text = _character.Name;
    }

    //foreach (Button button in _actionButtons) button.gameObject.SetActive(false); // must remember to get the gameObject, not just button component
}
