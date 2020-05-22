﻿// ----------------------------------------------------------------------------
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

[CreateAssetMenu(fileName = "StringVariable", menuName = "Variables/String Variable", order = 54)]
public class StringVariable : ScriptableObject
{
    public string Value;
}