using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "ColorSystemSO", menuName = "ScriptableObjects/ColorSystem/ColorSystemSO", order = 1)]
public class ColorSystemSO : SerializedScriptableObject
{
    public Dictionary<ColorSO, KeyCode> colorToKey = new Dictionary<ColorSO, KeyCode>();
}
