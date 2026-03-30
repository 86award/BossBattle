using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerCharacterSetup : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    public static PlayerCharacterSetup Instance;

    public static string PlayerCharacterName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ConfirmButton()
    {
        if (_inputField.text.Trim() != "")
        {
            PlayerCharacterName = _inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ClearButton()
    {
        _inputField.text = "";
    }
}