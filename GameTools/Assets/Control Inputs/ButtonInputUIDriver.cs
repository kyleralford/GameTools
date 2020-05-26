using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputUIDriver : MonoBehaviour
{
    public ButtonInput buttonInput;
    private Button buttonUI;

    private void Awake()
    {
        buttonUI = GetComponent<Button>();
    }

    void Update()
    {
        
    }
}
