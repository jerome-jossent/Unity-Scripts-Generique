using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour {
    public float scrollSpeed = 0.5F;
    private Renderer rend;
    public GameObject tapisCollider;
   
    void Start()
    {
        rend = GetComponent<Renderer>();
        
    }
    void Update()
    {
        scrollSpeed = tapisCollider.GetComponent<Convoyeur>().speed * (0.3125f);
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));

        



        //var d = Input.GetAxis("Mouse ScrollWheel");
        //if (d > 0f)
        //{
        //    // scroll up
        //    scrollSpeed += 0.05f;
        //}
        //else if (d < 0f)
        //{
        //    // scroll down
        //    scrollSpeed -= 0.05f;
        //}
    }
}
