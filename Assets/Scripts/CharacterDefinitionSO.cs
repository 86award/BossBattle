using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterDefintionSO", menuName = "Scriptable Objects/Character Definition", order = 1)]
public class CharacterDefinitionSO : ScriptableObject
{
    public string Name { get { return _name; } }

    [SerializeField]
    private string _name;

    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private Image portrain;
}
