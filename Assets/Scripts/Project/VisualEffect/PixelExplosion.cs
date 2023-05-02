using UnityEngine;

public class PixelExplosion : MonoBehaviour
{
    private ColorSO colorSO;
    [SerializeField]
    private float speed = 100f;

    public GameObject pixelPrefab;
    public int numberOfPixels = 100;

    public void Explode()
    {
        colorSO = GetComponent<Ball>().colorSO;
        for (int i = 0; i < numberOfPixels; i++)
        {
            GameObject pixel = Instantiate(pixelPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = pixel.GetComponent<Rigidbody2D>();
            SpriteRenderer spriteRenderer = pixel.GetComponent<SpriteRenderer>();
            spriteRenderer.color = colorSO.color;
            if (rb != null)
            {
                rb.AddForce(Random.insideUnitSphere * speed, ForceMode2D.Impulse);
            }

            Destroy(pixel, 2.0f); // Destroy pixel after 2 seconds
        }

        Destroy(gameObject); // Destroy original object
    }
}
