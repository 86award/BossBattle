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

        //_battleUI.button.DoNothing += CompleteAction; // I don't like that I need a reference to the button in the inspector to be able to subscribe
    }

    private void Start()
    {
        foreach (Character character in _heroPartyManager.GetPartyCharacterList()) _battleParticipants.Add(character);
        foreach (Character character in _monsterPartyManager.GetPartyCharacterList()) _battleParticipants.Add(character);

        foreach (Character character in _battleParticipants) character.RollInitiative(_random.Next(1, 21));
        Queue<Character> battleOrder = new Queue<Character>(from character in _battleParticipants
                                                            orderby character.InitiativeRoll descending
                                                            select character);

        BattleRound(battleOrder);
    }

    public void BattleRound(Queue<Character> battleOrder)
    {
        while (battleOrder.Count > 0)
        {
            Character activeCharacter = battleOrder.Dequeue();
            Debug.Log(activeCharacter);
            _battleUI._turnText.text = $"It's {activeCharacter}'s turn.";
            CharacterTurn(activeCharacter);
        }
    }

    public void CharacterTurn(Character character)
    {
        /*
         * The character is activated
         * // should I drive the game flow from character - no the battle manager is the coordinator
         * // the character should be notified that it's able to do something and deliver input back to the BattleManager
         * The UI should reflect the character is activated - text and buttons
         * // determine available actions for active character
         * // activate buttons for actions
         * The game should wait for the character to take an action be pressing a button
         * // enact action
         * The game will only progress once an action has been taken
         * Process action and provide feedback to player
         * The character should be deactivated and UI updated to reflect that
         * Check if battle has been won/lost
         * Play should pass to next character to activate
         */
        character.ActivateCharacter();
        StartCoroutine(WaitForMonsterTurn(character));
    }

    //public void CompleteAction()
    //{
    //    if (_isHeroTurn)
    //    {
    //        Debug.Log($"{_battleParticipants[0]} did nothing");
    //        _isHeroTurn = false;


    //        // I think I want to call an event here that makes it monster turn
    //        _battleUI.button.gameObject.SetActive(false);
    //        StartCoroutine(WaitForMonsterTurn());
    //    }
    //}

    public IEnumerator WaitForMonsterTurn(Character character)
    {
        yield return new WaitForSeconds(4);
        Debug.Log($"{character} did nothing");
        //_isHeroTurn = true;
        //_battleUI._turnText.text = $"It's {_battleParticipants[0]}'s turn.";
        //_battleUI.button.gameObject.SetActive(true);
    }

    /*
     * Owns battle flow and resolution
     * Runs the battle state machine
     * Determines whose turn it is
     * Evaluates win/loss using party-level queries
     * Coordinates turn transitions
    */
}