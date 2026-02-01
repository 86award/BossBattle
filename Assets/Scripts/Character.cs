using UnityEngine;
using TMPro;

public class Character : MonoBehaviour
{
    // Character will own the top level invariants and no other system can alter these rules
    /*
     * Health is never negative
     * Health cannot exceed max health unless explicity allowed
     * Dead characters cannot act
     * Death can only happen once
     * Name can never be null
     * 
     * Character should control and calculate damage results
     * Sub-classes can influence/own responses, not decisions
     */
    [SerializeField]
    private CharacterDefinitionSO characterDefinition;
    [SerializeField]
    public TextMeshProUGUI nameplate;


    private void Awake()
    {
        nameplate.text = characterDefinition.Name;
    }
}
