using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JoystickInput", menuName = "Inputs/Joystick", order = 52)]
public class JoystickInput : ScriptableObject
{
    public ButtonInput horizontalPositive;
    public ButtonInput horizontalNegative;
    public ButtonInput verticalPositive;
    public ButtonInput verticalNegative;

    [HideInInspector]
    public Vector2 valueNormalized;
    [HideInInspector]
    public Vector2 valueEased;

    void Update()
    {
        if (Input.GetButton("JoystickButton1") == true)
        {
            Debug.Log("Joystick Input");
        }
    }
}
