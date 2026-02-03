using UnityEngine;

[CreateAssetMenu(fileName = "AbilityDefinitionSO", menuName = "Scriptable Objects/Ability Definition", order = 4)]
public class AbilityDefinitionSO : ScriptableObject
{
    public string AbilityName { get { return _abilityName; } }
    public Sprite AbilityImage { get { return _abilityImage; } }

    [SerializeField]
    private string _abilityName;

    [SerializeField]
    private Sprite _abilityImage;
}
