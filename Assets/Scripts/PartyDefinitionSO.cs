using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "PartyDefinitionSO", menuName = "Scriptable Objects/Party Definition", order = 1)]
public class PartyDefinitionSO : ScriptableObject
{
    [SerializeField]
    private bool _isMonsters;
    public bool IsMonsterParty { get { return _isMonsters; } }

    [Header("Party Members")]
    [SerializeField]
    private List<CharacterDefinitionSO> _characters;
    public List<CharacterDefinitionSO> Characters { get { return _characters; } }

}
