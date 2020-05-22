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
public class FloatReference
{
    public bool UseConstant = false;
    public float ConstantValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return UseConstant ? ConstantValue : Variable.Value; }
    }
}
