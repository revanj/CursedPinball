using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomUtils
{
    public static KeyCode ParseKeyCode(string str)
    {
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), str);
    }
}
