using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoolVariable", menuName = "Inputs/Button", order = 51)]
public class ButtonInput : ScriptableObject
{
    [Tooltip("The keystroke or joystick button input for this InputButton.")]
    public string keystroke;
    [Tooltip("An alternate keystroke or joystick button input for this InputButton, not to be used for cross platform input.")]
    public string keystrokeAlt;
    [Tooltip("Amount of time after button press, in seconds, before a secondary button input is triggered.")]
    public float secondaryTimer;

    [HideInInspector]
    public bool isButtonPressed = false;
    [HideInInspector]
	public bool onButtonDown = false;
    [HideInInspector]
	public bool onButtonTimer = false;
    [HideInInspector]
	public bool onButtonUp = false;

    private void Awake()
    {
        if (keystroke == null)
        {
            Debug.Log("Missing keycode for ButtonInput \"" + name + "\".");
        }
    }
}
