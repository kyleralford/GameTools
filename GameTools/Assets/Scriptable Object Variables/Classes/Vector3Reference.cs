// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
//
// Edited by Kyler Alford for use in his projects
// ----------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vector3Reference
{
    public bool UseConstant = false;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;

    public Vector3 Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}