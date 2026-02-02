using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterDefintionSO", menuName = "Scriptable Objects/Character Definition", order = 2)]
public class CharacterDefinitionSO : ScriptableObject
{
    public string Name { get { return _name; } }
    public Sprite SpriteIdle {  get { return spriteIdle; } }

    [SerializeField]
    private string _name;

    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private Sprite spriteIdle;
}
