using UnityEngine;
using TMPro;
using System;
using Unity;
using UnityEngine.SceneManagement;


public class PlayerCharacterSetup : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    public static PlayerCharacterSetup Instance;

    public static string Name;

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
            Debug.Log("Saving name.");
            Name = _inputField.text;
            SceneManager.LoadScene(1);
        }
    }

    public void ClearButton()
    {
        Debug.Log("Clearing");
        _inputField.text = "";
    }
}