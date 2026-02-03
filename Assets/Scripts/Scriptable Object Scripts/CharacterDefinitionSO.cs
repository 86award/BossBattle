using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterDefintionSO", menuName = "Scriptable Objects/Character Definition", order = 3)]
public class CharacterDefinitionSO : ScriptableObject
{
    public string Name { get { return _name; } }
    public Sprite SpriteIdle {  get { return _spriteIdle; } }
    public int IntBonus {  get { return _initiativeRollBonus; } }

    [SerializeField]
    private string _name;

    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private Sprite _spriteIdle;

    [SerializeField]
    private int _initiativeRollBonus;
}
