using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{
    public GameObject characterPrefab;

    [SerializeField]
    private Transform _spawnLocation;

    private PartyDefinitionSO _partyDefinition;

    [Header("Party Members")]
    [SerializeField]
    private List<GameObject> _characters; // changed from List<Character>

    public void SetPartyDefinition(PartyDefinitionSO partyDefinitionSO)
    {
        _partyDefinition = partyDefinitionSO;
    }

    public void GeneratePartyCharacters()
    {
        foreach (CharacterDefinitionSO character in _partyDefinition.Characters)
        {
            GameObject characterObject = Instantiate(characterPrefab, _spawnLocation);
            Character characterScript = characterObject.GetComponent<Character>();
            characterScript.InitCharacter(character);
            _characters.Add(characterObject);
            if (_partyDefinition.IsMonsterParty) characterObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
    }
}
