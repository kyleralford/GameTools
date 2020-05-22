using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Inputs/Button", order = 51)]
public class ButtonInput : ScriptableObject
{
    [Tooltip("The keystroke or joystick button input for this InputButton.")]
    public string keystroke;
    [Tooltip("An alternate keystroke or joystick button input for this InputButton, typically for cross platform input.")]
    public string keystrokeAlt;

    [HideInInspector]
    public bool isButtonPressed = false;
    [HideInInspector]
	public bool onButtonDown = false;
    [HideInInspector]
	public bool onButtonTimer = false;
    [HideInInspector]
	public bool onButtonUp = false;
}
