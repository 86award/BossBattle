using TMPro;
using UnityEngine;

public class BattleManager_UI : MonoBehaviour
{
    public TextMeshProUGUI TurnText { get { return _turnText; } }
    public TextMeshProUGUI RoundText { get { return _roundText; } }

    [SerializeField]
    private TextMeshProUGUI _turnText;

    [SerializeField]
    private TextMeshProUGUI _roundText;
}
