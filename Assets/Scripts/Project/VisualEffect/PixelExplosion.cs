using UnityEngine;

public class PixelExplosion : MonoBehaviour
{
    public GameObject pixelPrefab;
    public int numberOfPixels = 100;

    public void Explode()
    {
        for (int i = 0; i < numberOfPixels; i++)
        {
            GameObject pixel = Instantiate(pixelPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = pixel.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(Random.insideUnitSphere * 5.0f, ForceMode.Impulse);
            }

            Destroy(pixel, 2.0f); // Destroy pixel after 2 seconds
        }

        Destroy(gameObject); // Destroy original object
    }
}
