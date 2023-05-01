using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Rendering.Universal;

public abstract class Platform : MonoBehaviour
{
    [SerializeField]
    [Required]
    protected ColorSO colorSO;
    [SerializeField]
    [Required]
    protected SpriteRenderer colorRenderer;
    [SerializeField]
    [Required]
    protected ColorSystemSO colorSystemSO;
    [SerializeField]
    protected float moveSpeed = 5f;
    [SerializeField]
    protected Rigidbody2D rb;
    protected KeyCode keyCode
    {
        get
        {
            return colorSystemSO.colorToKey[colorSO];
        }
    }

    private void OnValidate()
    {
        if (colorRenderer == null) { return; }
        SpriteRenderer[] spriteRenderers = colorRenderer.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = colorSO.color;
        }
    }
}

public interface IRotateable
{
    List<float> WayPoints { get; }
}

public interface ITranslateable
{
    List<Transform> WayPoints { get; }
}