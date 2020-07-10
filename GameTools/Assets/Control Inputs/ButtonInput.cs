using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ButtonInput", menuName = "Inputs/Button", order = 51)]
public class ButtonInput : ScriptableObject
{
    [Tooltip("The keystroke or joystick button input for this InputButton.")]
    public string keystroke;
    [Tooltip("An alternate keystroke or joystick button input for this InputButton, not to be used for cross platform input.")]
    public string keystrokeAlt;
    [Tooltip("Amount of time after button press, in seconds, before a secondary button input is triggered.")]
    public float secondaryTimer;
    [Tooltip("If true, the onButtonUp variable will not trigger to 'true' if the onButtonTimer is triggered.")]
    public bool doesTimerSkipUp = true;

    [HideInInspector]
    public bool isButtonPressed = false;
    [HideInInspector]
    public bool virtualPress = false;
    [HideInInspector]
    public float virtualTimer = 0.0f;
    [HideInInspector]
    public bool virtualButtonHold = false;
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

// A way to press the button from code (for one frame)
    public void VirtualPress()
    {
        virtualPress = true;
    }

// A way to press the button from code (for a specified amount of time - if set to 0.0f, will default to the minimum amount of time to activate the secondary timer
    public void VirtualTimer(float timer)
    {
        if (timer == 0.0f)
        {
            virtualTimer = secondaryTimer;
        }
        else
        {
            virtualTimer = timer;
        }
    }

// A way to press the button from code (indefinitely / until VirtualHoldStop() is called)
    public void VirtualHoldStart()
    {
        virtualButtonHold = true;
    }

    public void VirtualHoldStop()
    {
        virtualButtonHold = false;
    }
}
