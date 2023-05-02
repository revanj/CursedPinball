using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonShaderChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Material newMaterial;
    private Material originalMaterial;
    private Image buttonImage;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        originalMaterial = buttonImage.material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.material = newMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.material = originalMaterial;
    }
}
