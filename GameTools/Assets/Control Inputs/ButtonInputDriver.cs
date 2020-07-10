using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/*
 *  If trying to press the button via script, use the VirtualPress() method for a single frame press
 *  Use VirtualHoldStart() and VirtualHoldStop() for a virtual hold
 *  Use VirtualTimer(float) to hold for a specific amount of time (in frames)
 *      - a value of 0.0f will default to pressing the button until the secondary timer triggers
 */

public class ButtonInputDriver : MonoBehaviour
{
    public ButtonInput buttonInput;
	[TextArea (0, 10)]
	public string Notes = "Description of button usage.";
    private Button buttonUI;
    private float buttonPressLength = 0.0f;
    private bool buttonTimerTriggered = false;
    private bool isUIButtonPressed = false;
    private bool lastFramePressed = false;
    private bool isSkippingUp = false;

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
        if (buttonInput.keystroke == "" && buttonInput.keystrokeAlt == "" && buttonUI == null)
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
        if (buttonInput.keystroke != "")
        {
            if (Input.GetKey(buttonInput.keystroke) == true)
            {
                buttonInput.isButtonPressed = true;
            }
        }
        else if (buttonInput.keystrokeAlt != "")
        {
            if (Input.GetKey(buttonInput.keystrokeAlt) == true)
            {
                buttonInput.isButtonPressed = true;
            }
        }
        else if (isUIButtonPressed == true)
        {
            buttonInput.isButtonPressed = true;
        }
        else if (buttonInput.virtualPress == true)
        {
            buttonInput.isButtonPressed = true;
            buttonInput.virtualPress = false;
        }
        else if (buttonInput.virtualButtonHold == true)
        {
            buttonInput.isButtonPressed = true;
        }
        
        if (buttonInput.virtualTimer > 0.0f) // The virtualTimer condition has no 'else' because it needs to have time subtracted even if the button has already registered as pressed.
        {
            buttonInput.isButtonPressed = true;
            buttonInput.virtualTimer -= Time.deltaTime;
            if (buttonInput.virtualTimer < 0.0f)
            {
                buttonInput.virtualTimer = 0.0f;
            }
        }

// Cases for onButtonDown and onButtonUp
        if (buttonInput.isButtonPressed == true && lastFramePressed == false)
        {
            buttonInput.onButtonDown = true;
            buttonPressLength = 0.0f;
            isSkippingUp = false;
        }
        else if (buttonInput.isButtonPressed == false && lastFramePressed == true)
        {
            buttonTimerTriggered = false;
            if (!isSkippingUp)
            {
                buttonInput.onButtonUp = true;
            }
        }
// Set lastFramePressed for the next frame
        lastFramePressed = buttonInput.isButtonPressed;

// Setting the "OnButtonTimer" bool
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
                if (buttonInput.doesTimerSkipUp == true)
                {
                    isSkippingUp = true;
                }
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
