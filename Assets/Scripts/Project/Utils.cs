using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static bool IsGameObjectOutOfScreenBounds(GameObject gameObject, Camera camera)
    {
        // Get the bounds of the screen in world space.
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(cameraHeight * screenAspect, cameraHeight);
        Vector2 cameraMin = (Vector2)camera.transform.position - cameraSize / 2f;
        Vector2 cameraMax = (Vector2)camera.transform.position + cameraSize / 2f;

        // Check if the gameobject's position is outside of the screen bounds.
        Vector2 gameObjectPos = camera.WorldToViewportPoint(gameObject.transform.position);
        return gameObjectPos.x < 0f || gameObjectPos.x > 1f || gameObjectPos.y < 0f || gameObjectPos.y > 1f;
    }
}
