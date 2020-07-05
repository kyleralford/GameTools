using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFramerate : MonoBehaviour
{
    public int targetFramerate = 30;

    private void Awake()
    {
        Application.targetFrameRate = targetFramerate;
    }
}
