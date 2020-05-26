using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputDriver : MonoBehaviour
{
    public ButtonInput buttonInput;
    private float buttonPressLength = 0.0f;
    private bool buttonTimerTriggered = false;

    void Update()
    {
        // Setting the "ButtonDown" bool
        buttonInput.onButtonDown = Input.GetKeyDown(buttonInput.keystroke);
        if (buttonInput.onButtonDown == false && buttonInput.keystrokeAlt != null)
        {
            buttonInput.onButtonDown = Input.GetKeyDown(buttonInput.keystrokeAlt);
        }
        if (buttonInput.onButtonDown)
        {
            buttonInput.isButtonPressed = true;
        }

        // Setting the "ButtonUp" bool
        buttonInput.onButtonUp = Input.GetKeyUp(buttonInput.keystroke);
        if (buttonInput.onButtonUp == false && buttonInput.keystrokeAlt != null)
        {
            buttonInput.onButtonUp = Input.GetKeyUp(buttonInput.keystrokeAlt);
        }
        if (buttonInput.onButtonUp)
        {
            buttonInput.isButtonPressed = false;
        }

        // Setting the "OnButtonTimer" bool
        if (buttonInput.onButtonDown)
        {
            buttonPressLength = 0.0f;
        }
        if (buttonInput.onButtonUp)
        {
            buttonTimerTriggered = false;
        }
        if (buttonInput.onButtonTimer)
        {
            buttonInput.onButtonTimer = false;
        }
        if (buttonInput.isButtonPressed)
        {
            buttonPressLength += Time.deltaTime;
            if (buttonPressLength >= buttonInput.secondaryTimer && buttonTimerTriggered == false)
            {
                buttonInput.onButtonTimer = true;
                buttonTimerTriggered = true;
            }
        }

    }
}
