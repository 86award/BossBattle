using UnityEngine;
using System.Collections.Generic;
using System;
using TMPro;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    // get a reference to each party taking part in the battle
    // the battle manager should know what parties are in the battle
    // * Knows that parties exist, not how they work internally
    [SerializeField]
    private BattleDefinitionSO _battleDefinition;

    // * Holds references to PartyManagers
    [SerializeField]
    private PartyManager _heroPartyManager;

    [SerializeField]
    private PartyManager _monsterPartyManager;

    [SerializeField]
    private TextMeshProUGUI _turnText;

    [SerializeField]
    private UI_Button_CharacterAction button;

    private void Awake()
    {
        _heroPartyManager.SetPartyDefinition(_battleDefinition.HeroPartySO);
        _monsterPartyManager.SetPartyDefinition(_battleDefinition.MonsterPartySO);


        _heroPartyManager.GeneratePartyCharacters();
        _monsterPartyManager.GeneratePartyCharacters();

        button.DoNothing += CompleteAction; // I don't like that I need a reference to the button in the inspector to be able to subscribe
    }

    [SerializeField]
    private List<Character> _battleParticipants;

    private bool isHeroTurn;

    private void Start()
    {
        /*
         * need to look at how I can embrace DRY and avoid repetition of these foreach loops
         */
        // get all characters and store in character list
        foreach (Character character in _heroPartyManager.GetPartyCharacterList())
        {
            _battleParticipants.Add(character);
        }
        foreach (Character character in _monsterPartyManager.GetPartyCharacterList())
        {
            _battleParticipants.Add(character);
        }

        isHeroTurn = true;
        _turnText.text = $"It's {_battleParticipants[0]}'s turn.";
    }

    private void Update()
    {
        // Start with one character being able to play
        // need to post/communicate to the player whos turn it is
        
    }

    public void CompleteAction()
    {
        if (isHeroTurn)
        {
            Debug.Log($"{_battleParticipants[0]} did nothing");
            isHeroTurn = false;
            _turnText.text = $"It's {_battleParticipants[5]}'s turn."; // won't work with magic numbers and variable number of combatants
            /*
             * This might be a good place to look at using a queue or stack etc.
             */

            // I think I want to call an event here that makes it monster turn
            button.gameObject.SetActive(false);
            StartCoroutine(WaitForMonsterTurn());
        }
    }

    public IEnumerator WaitForMonsterTurn()
    {
        yield return new WaitForSeconds(4);
        Debug.Log($"{_battleParticipants[1]} did nothing");
        isHeroTurn = true;
        _turnText.text = $"It's {_battleParticipants[0]}'s turn.";
        button.gameObject.SetActive(true);
    }

    /*
     * Owns battle flow and resolution
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
