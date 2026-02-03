using UnityEngine;
using System.Collections.Generic;
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
    public List<AbilityDefinitionSO> Abilities { get { return _abilities; } }

    private CharacterDefinitionSO _characterDefinition;
    private int _initiativeRoll;
    private int _initiativeBonus;
    private string _name;
    private List<AbilityDefinitionSO> _abilities;

    [SerializeField]
    private SpriteRenderer _characterVisuals;

    public event Action UpdateNamePlate;
    public event Action CharacterActivated;
    public event Action PopulateAbilityUI;

    public void InitCharacter(CharacterDefinitionSO charDef)
    {
        _characterDefinition = charDef;
        _name = _characterDefinition.Name;
        _characterVisuals.sprite = _characterDefinition.SpriteIdle;
        _initiativeBonus = _characterDefinition.IntBonus;
        _abilities = _characterDefinition.Abilities; // populate the list with abilities from the SO
        UpdateNamePlate.Invoke();
        PopulateAbilityUI.Invoke();
    }

    public void ActivateCharacter()
    {
        CharacterActivated.Invoke();
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
