using System;
using UnityEngine;

public class UI_Button_CharacterAction : MonoBehaviour
{
    public event Action DoNothing;

    public void ButtonPressed()
    {
        DoNothing.Invoke();
    }
}
