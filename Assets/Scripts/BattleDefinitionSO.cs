using UnityEngine;

[CreateAssetMenu(fileName = "BattleDefinitionSO", menuName = "Scriptable Objects/Battle Definition", order = 3)]
public class BattleDefinitionSO: ScriptableObject
{
    [SerializeField]
    private PartyDefinitionSO _heroParty;
    [SerializeField]
    private PartyDefinitionSO _monsterParty;

    public PartyDefinitionSO HeroPartySO { get { return _heroParty; } }
    public PartyDefinitionSO MonsterPartySO { get { return _monsterParty; } }
}
