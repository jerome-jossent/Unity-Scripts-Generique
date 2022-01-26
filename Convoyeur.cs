using UnityEngine;

public class Convoyeur : MonoBehaviour {
 
    public float speed = 0.32f;
    
    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus) ) speed += 0.05f;
        if (Input.GetKeyUp(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus)) speed -= 0.05f;
    }

    void OnCollisionStay(Collision collision)
    {
        collision.gameObject.transform.position -= speed * Time.deltaTime * transform.forward;
    }
}
