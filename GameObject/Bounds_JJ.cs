using UnityEngine;

public class Bounds_JJ { 

    public static UnityEngine.Bounds Calculate(Transform TheObject)
    {
        var renderers = TheObject.GetComponentsInChildren<Renderer>();
        UnityEngine.Bounds combinedBounds = renderers[0].bounds;
        for (int i = 1; i < renderers.Length; i++)
        {
            combinedBounds.Encapsulate(renderers[i].bounds);
        }
        return combinedBounds;
    }
}
