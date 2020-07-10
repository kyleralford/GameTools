using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProControllerTest : MonoBehaviour
{
    public ButtonInput buttonInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("That button was pressed.");
        } */

        if (buttonInput.onButtonDown)
        {
            Debug.Log("That button was pressed.");
        }
    }
}
