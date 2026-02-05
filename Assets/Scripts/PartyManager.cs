using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
/*
* Owns party composition and party-wide state
* Knows which characters are alive or ready
*/
    public GameObject characterPrefab;

    [SerializeField]
    private List<Transform> _spawnLocation;

    private PartyDefinitionSO _partyDefinition;

    [Header("Party Members")]
    [SerializeField]
    private List<Character> _characters;

    public void SetPartyDefinition(PartyDefinitionSO partyDefinitionSO)
    {
        _partyDefinition = partyDefinitionSO;
    }

    public List<Character> GetPartyCharacterList()
    {
        return _characters;
    }

    public void GeneratePartyCharacters()
    {
        int i = 0;
        foreach (CharacterDefinitionSO character in _partyDefinition.Characters)
        {
            if (i >= _partyDefinition.Characters.Count) break;
            GameObject characterObject = Instantiate(characterPrefab, _spawnLocation[i]);
            Character characterScript = characterObject.GetComponent<Character>();
            
            // getting the name from the static player character setup object
            if (character.IsCustomName) characterScript.CustomName = PlayerCharacterSetup.Name;
            characterScript.InitCharacter(character);
            _characters.Add(characterScript);
            /*
                * What's interesting here is that I can add the characterScript to the _characters List 
                * and it adds the game object which is what I was wanting to do. I didn't realise you 
                * could do that.
                */
            if (_partyDefinition.IsMonsterParty) characterObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            i++;
        }
    }
}
