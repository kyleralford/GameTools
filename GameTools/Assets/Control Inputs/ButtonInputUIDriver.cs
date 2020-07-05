using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInputUIDriver : MonoBehaviour
{
    public ButtonInput buttonInput;
    private Button buttonUI;
    private bool lastButtonEventRegistered = false;
    private float buttonPressLength = 0.0f;
    private bool buttonTimerTriggered = false;

    private void Awake()
    {
        buttonUI = GetComponent<Button>();

        // Debug to make sure EventTrigger exists.
        if (GetComponent<EventTrigger>() == null)
        {
            Debug.Log("An event trigger with Pointer Up and Pointer Down events linked to ButtonDown and ButtonUp methods must be added to " + name + ".");
        }
    }

    void Update()
    {
        // Reset onButtonDown
        if (buttonInput.onButtonDown)
        {
            if (lastButtonEventRegistered)
            {
                buttonInput.onButtonDown = false;
                lastButtonEventRegistered = false;
            }
            else
            {
                lastButtonEventRegistered = true;
            }
        }
        // Reset onButtonUp
        if (buttonInput.onButtonUp)
        {
            if (lastButtonEventRegistered)
            {
                buttonInput.onButtonUp = false;
                lastButtonEventRegistered = false;
            }
            else
            {
                lastButtonEventRegistered = true;
            }
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

    public void ButtonDown()
    {
        buttonInput.isButtonPressed = true;
        buttonInput.onButtonDown = true;
    }

    public void ButtonUp()
    {
        buttonInput.isButtonPressed = false;
        buttonInput.onButtonUp = true;
    }
}
