using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonInputDriver : MonoBehaviour
{
    public ButtonInput buttonInput;
    private Button buttonUI;
    private float buttonPressLength = 0.0f;
    private bool buttonTimerTriggered = false;
    private bool isUIButtonPressed = false;
    private bool lastFramePressed = false;

    private void Awake()
    {
        if (GetComponent<Button>() != null)
        {
            buttonUI = GetComponent<Button>();
        }

        // Throw debugs in case of missing dependencies
        if (buttonInput == null)
        {
            Debug.Log(name + " is missing a reference to a buttonInput.");
        }
        if (buttonInput.keystroke == null && buttonInput.keystrokeAlt == null && buttonUI == null)
        {
            Debug.Log("Button Input " + buttonInput.name + " has not been set up properly. This buttonInput needs to have keystrokes assigned, or must be attached to a UI Button.");
        }
        else if (buttonUI != null && GetComponent<EventTrigger>() == null)
        {
            Debug.Log(name + " is attempting to drive a buttonInput with a UI button but needs an event trigger pointing to the PointerDown and PointerUp methods.");
        }
    }

    void Update()
    {
        // Reset the onDown and onUp and onTimer triggers
        buttonInput.isButtonPressed = false;
        buttonInput.onButtonDown = false;
        buttonInput.onButtonUp = false;
        buttonInput.onButtonTimer = false;

        // Get all the isButtonPressedInputs
        if (Input.GetKey(buttonInput.keystroke) == true)
        {
            buttonInput.isButtonPressed = true;
        }
        if (buttonInput.isButtonPressed == false && Input.GetKey(buttonInput.keystrokeAlt) == true)
        {
            buttonInput.isButtonPressed = true;
        }
        if (buttonInput.isButtonPressed == false && isUIButtonPressed == true)
        {
            buttonInput.isButtonPressed = true;
        }

        // Cases for onButtonDown and onButtonUp
        if (buttonInput.isButtonPressed == true && lastFramePressed == false)
        {
            buttonInput.onButtonDown = true;
        }
        else if (buttonInput.isButtonPressed == false && lastFramePressed == true)
        {
            buttonInput.onButtonUp = true;
        }
        // Set lastFramePressed for the next frame
        lastFramePressed = buttonInput.isButtonPressed;

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

    public void PointerDown()
    {
        isUIButtonPressed = true;
    }

    public void PointerUp()
    {
        isUIButtonPressed = false;
    }

}
