using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProControllerTest : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("The 'B' button was pressed.");
        }

        if (Input.GetKeyDown("joystick button 11"))
        {
            Debug.Log("The right stick was clicked.");
        }

        Debug.Log(Input.GetAxis("Horizontal"));
    }
}
