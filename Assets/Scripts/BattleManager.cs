using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

/*
 * Owns battle flow and resolution
 * Runs the battle state machine
 * Determines whose turn it is
 * Evaluates win/loss using party-level queries
 * Coordinates turn transitions
*/
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
    private List<Character> _battleRoster;

    [SerializeField]
    private Queue<Character> _battleOrder;

    private System.Random _random = new System.Random();

    private void Awake()
    {
        /*
         * This effectively sets up a battle for a specific level
         * - use battle definition SO to assign groups to party managers
         * - instantiate character instance for each character and add to single battle roster
        */
        _heroPartyManager.SetPartyDefinition(_battleDefinition.HeroPartySO);
        _monsterPartyManager.SetPartyDefinition(_battleDefinition.MonsterPartySO);

        _heroPartyManager.GeneratePartyCharacters();
        _monsterPartyManager.GeneratePartyCharacters();

        foreach (Character character in _heroPartyManager.GetPartyCharacterList()) _battleRoster.Add(character);
        foreach (Character character in _monsterPartyManager.GetPartyCharacterList()) _battleRoster.Add(character);
    }

    private void Start()
    {
        InitialiseBattleRound();
    }

    private void InitialiseBattleRound()
    {
        BuildCharacterTurnOrder();
        TurnSelection();
        //WaitingForAction();
        //ActionResolution();
        //PostActionChecks();
    }

    private void BuildCharacterTurnOrder()
    {
        // I'm going to need to remember to rebuild the party lists after every turn just in case a character dies
        // in fact this should be taken care of because when health gets to zero I'll kill the character and remove them from partySO
        _battleOrder = RollInitiative();
    }
    private Queue<Character> RollInitiative()
    {
        foreach (Character character in _battleRoster) character.RollInitiative(_random.Next(1, 21));
        Queue<Character> battleOrder = new Queue<Character>(from character in _battleRoster
                                                            orderby character.InitiativeRoll descending
                                                            select character);
        return battleOrder;
    }

    private Character _currentCharacter;

    private void TurnSelection()
    {
        // Unsubscribe from previous character to avoid duplicate subscribing
        if (_currentCharacter != null)
        {
            _currentCharacter.ActionSelected -= WaitingForAction;
        }
        Character nextCharacter = _battleOrder.Dequeue();
        _currentCharacter = nextCharacter;
        nextCharacter.ActionSelected += WaitingForAction;
        _battleUI._turnText.text = $"It's {nextCharacter}'s turn.";
        nextCharacter.ActivateCharacter(); // event will be fired for each character
    }

    private void WaitingForAction(AbilityDefinitionSO ability)
    {
        Debug.Log($"Action selected: {ability.AbilityName}");
        /*
         * The character is activated
         * // should I drive the game flow from character - no the battle manager is the coordinator, it decides when somthing should happen
         * // the character should be notified that it's able to do something and deliver input back to the BattleManager, the character decides how they act
         * The UI should reflect the character is activated - text and buttons
         * // determine available actions for active character
         * // activate buttons for actions
         * The game should wait for the character to take an action be pressing a button
         * // enact action and supply actions to affected objects, the battle manager directly modify character fields/set health values
         * The game will only progress once an action has been taken
         * Process action and provide feedback to player
         * The character should be deactivated and UI updated to reflect that
         * Play should pass to next character to activate
         */
        PostActionChecks();
    }
    private void PostActionChecks()
    {
        // win/lose and whether there are unactivated characters remaining
        if (_battleOrder.Count > 0) TurnSelection();
        else
        {
            Debug.Log("Battle Round complete. Starting new round.");
            InitialiseBattleRound();
        }
    }
}