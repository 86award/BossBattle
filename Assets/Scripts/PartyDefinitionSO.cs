using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "PartyDefinitionSO", menuName = "Scriptable Objects/Party Definition", order = 1)]
public class PartyDefinitionSO : ScriptableObject
{
    // No gameplay logic must be in SO
    [Header("Party Members")]
    [SerializeField]
    private List<CharacterDefinitionSO> _characters;
    public List<CharacterDefinitionSO> Characters { get { return _characters; } }

}
