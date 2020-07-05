using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputDebug : MonoBehaviour
{
    public ButtonInput testInput;
    public int cycles = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testInput.onButtonDown)
        {
            cycles += 1;
            Debug.Log("Button has been pressed down " + cycles + " times.");
        }
    }
}
