using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Character : MonoBehaviour
{
    // Character will own the top level invariants and no other system can alter these rules
    /*
     * Health is never negative
     * Health cannot exceed max health unless explicity allowed
     * Dead characters cannot act
     * Death can only happen once
     * Name can never be null
     * 
     * Character should control and calculate damage results
     * Sub-classes can influence/own responses, not decisions
     * 
     * Owns personal state and invariants
     * Responds to damage and effects
     */

    public int InitiativeRoll { get { return _initiativeRoll; } }
    public int InitiativeBonus { get { return _initiativeBonus; } }
    public string Name { get { return _name; } }

    private CharacterDefinitionSO _characterDefinition;
    private int _initiativeRoll;
    private int _initiativeBonus;
    private string _name;

    [SerializeField]
    private SpriteRenderer _characterVisuals;

    public event Action UpdateNamePlate;

    public void InitCharacter(CharacterDefinitionSO charDef)
    {
        _characterDefinition = charDef;
        _name = _characterDefinition.Name;
        _characterVisuals.sprite = _characterDefinition.SpriteIdle;
        _initiativeBonus = _characterDefinition.IntBonus;
        UpdateNamePlate.Invoke();
    }

    public void ActivateCharacter()
    {
        //foreach (Button button in _actionButtons) button.gameObject.SetActive(true);
    }

    public void RollInitiative(int randomRoll)
    {
        _initiativeRoll = randomRoll + _initiativeBonus;
    }

    public override string ToString()
    {
        return _characterDefinition.Name;
    }
}
