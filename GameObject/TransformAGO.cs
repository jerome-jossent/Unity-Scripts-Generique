using UnityEngine;

public class TransformAGO : MonoBehaviour {

    public float RotationArround_X_Speed = 0.0f;
    public float RotationArround_Y_Speed = 0.0f;
    public float RotationArround_Z_Speed = 0.0f;
    	
	void Update() {
        transform.Rotate(RotationArround_X_Speed, 
                         RotationArround_Y_Speed, 
                         RotationArround_Z_Speed);
    }
}
