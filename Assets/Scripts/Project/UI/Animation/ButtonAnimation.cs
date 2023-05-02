using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonAnimation : MonoBehaviour
{
    public Button yourButton;
    public Vector3 biggerScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Vector3 originalScale = new Vector3(1f, 1f, 1f);
    public float duration = 1f;

    private Tweener tweener;

    private void Start()
    {
        if (yourButton == null)
        {
            Debug.LogError("Button reference is not set");
            return;
        }

        RectTransform buttonRectTransform = yourButton.GetComponent<RectTransform>();
        
        // Make sure the button starts at its original scale
        buttonRectTransform.localScale = originalScale;

        // Set up the tween
        tweener = buttonRectTransform.DOScale(biggerScale, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void OnDestroy()
    {
        // Always kill tweens when the object they're attached to is destroyed, 
        // or they will cause problems
        tweener.Kill();
    }
}
