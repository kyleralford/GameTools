using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputDriverTest : MonoBehaviour
{
    public ButtonInput buttonInput;

    // Update is called once per frame
    void Update()
    {
        if (buttonInput.onButtonDown)
        {
            transform.position = new Vector3(1.0f, 0.0f, 0.0f);
        }
        if (buttonInput.onButtonUp)
        {
            transform.position = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (buttonInput.onButtonTimer)
        {
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
