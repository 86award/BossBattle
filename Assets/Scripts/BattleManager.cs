using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private BattleDefinitionSO _battleDefinition;

    [SerializeField]
    private PartyManager _heroPartyManager;

    [SerializeField]
    private PartyManager _monsterPartyManager;

    [SerializeField]
    private BattleManager_UI _battleUI;

    [SerializeField]
    private List<Character> _battleParticipants;
    
    private bool _isHeroTurn;
    private System.Random _random = new System.Random();

    private void Awake()
    {
        _heroPartyManager.SetPartyDefinition(_battleDefinition.HeroPartySO);
        _monsterPartyManager.SetPartyDefinition(_battleDefinition.MonsterPartySO);

        _heroPartyManager.GeneratePartyCharacters();
        _monsterPartyManager.GeneratePartyCharacters();

        _battleUI.button.DoNothing += CompleteAction; // I don't like that I need a reference to the button in the inspector to be able to subscribe
    }

    private void Start()
    {
        foreach (Character character in _heroPartyManager.GetPartyCharacterList())
        {
            _battleParticipants.Add(character);
        }
        foreach (Character character in _monsterPartyManager.GetPartyCharacterList())
        {
            _battleParticipants.Add(character);
        }

        foreach(Character character in _battleParticipants)
        {
            character.RollInitiative(_random.Next(1, 21));
            Debug.Log($"{character} rolled a {character.InitiativeRoll} inc. (+{character.InitiativeBonus} bonus).");
        }

        Queue<Character> battleOrder = new Queue<Character>(from character in _battleParticipants
                                                            orderby character.InitiativeRoll descending
                                                            select character);

        foreach (Character character in battleOrder) Debug.Log(character);

        Debug.Log($"{battleOrder.Dequeue()}'s turn.");

        _isHeroTurn = true;
        _battleUI._turnText.text = $"It's {_battleParticipants[0]}'s turn.";
    }

    private void Update()
    {
        // Start with one character being able to play
        // need to post/communicate to the player whos turn it is
        
    }

    public void CompleteAction()
    {
        if (_isHeroTurn)
        {
            Debug.Log($"{_battleParticipants[0]} did nothing");
            _isHeroTurn = false;
            _battleUI._turnText.text = $"It's {_battleParticipants[5]}'s turn."; // won't work with magic numbers and variable number of combatants
            /*
             * This might be a good place to look at using a queue or stack etc.
             */

            // I think I want to call an event here that makes it monster turn
            _battleUI.button.gameObject.SetActive(false);
            StartCoroutine(WaitForMonsterTurn());
        }
    }

    public IEnumerator WaitForMonsterTurn()
    {
        yield return new WaitForSeconds(4);
        Debug.Log($"{_battleParticipants[1]} did nothing");
        _isHeroTurn = true;
        _battleUI._turnText.text = $"It's {_battleParticipants[0]}'s turn.";
        _battleUI.button.gameObject.SetActive(true);
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
