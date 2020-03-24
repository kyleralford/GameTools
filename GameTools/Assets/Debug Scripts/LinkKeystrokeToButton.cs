using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LinkKeystrokeToButton : MonoBehaviour
{

    [SerializeField] private string keystroke = null;
    private Button button;

    void Start()
    {
        if (!Application.isEditor)
        {
            enabled = false;
        }
        button = GetComponent<Button>();
    }

    void Update()
    {
        var pointer = new PointerEventData(EventSystem.current);

        if (Input.GetKeyDown(keystroke))
        {
            ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerDownHandler);
        }

        if (Input.GetKeyUp(keystroke))
        {
            ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerUpHandler);
        }
    }
}
