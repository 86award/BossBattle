using UnityEngine;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{
    // get a reference to each party taking part in the battle
    // the battle manager should know what parties are in the battle
    [SerializeField]
    private BattleDefinitionSO _battleDefinition;

    [SerializeField]
    private PartyManager _heroPartyManager;

    [SerializeField]
    private PartyManager _monsterPartyManager;

    private void Awake()
    {
        _heroPartyManager.SetPartyDefinition(_battleDefinition.HeroPartySO);
        _heroPartyManager.GeneratePartyCharacters();
        _monsterPartyManager.SetPartyDefinition(_battleDefinition.MonsterPartySO);
        _monsterPartyManager.GeneratePartyCharacters();
    }

    /*
     * Holds references to PartyManagers
     * Runs the battle state machine
     * Determines whose turn it is
     * Evaluates win/loss using party-level queries
     * Coordinates turn transitions
    */

    // determine which character will go first
    // need to decide if it's alternating activations or initiative based - former is easier for now

    // loop the below
    // prompt active character for action
    // process action
    // provide feedback based on action
    // check if battle has satisfied win/lose criteria
    // pass play to next character
}
