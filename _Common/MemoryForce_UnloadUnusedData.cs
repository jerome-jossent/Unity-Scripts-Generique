using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryForce_UnloadUnusedData : MonoBehaviour
{
    public float t_periode_s = 1;
    float next_t;

    void Update()
    {
        if (next_t > Time.time)
            return;

        next_t += t_periode_s;
        _CleanMemory();
    }

    public static void _CleanMemory()
    {
        Resources.UnloadUnusedAssets();
    }
}
