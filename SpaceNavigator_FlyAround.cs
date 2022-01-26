using UnityEngine;
using SpaceNavigatorDriver;

public class SpaceNavigator_FlyAround : MonoBehaviour
{
    public bool HorizonLock = true;
    public KeyCode SpeedKey_Increase;
    public KeyCode SpeedKey_Decrease;
    public KeyCode SpeedKey_Reset;
    public float SpeedFactor_Max = 10f;
    public float SpeedFactor_Min = 0.1f;
    public float SpeedFactor_Step = 2;
    float SpeedFactor = 1;

    public float TimeToShow = 2f;
    float TimeToHide;
    float GUI_alpha;

    public void Update()
    {
        if (Input.GetKeyDown(SpeedKey_Reset))
            SpeedFactor = 1.0f;
        if (Input.GetKeyDown(SpeedKey_Decrease))
            changefactor(1 / SpeedFactor_Step);
        if (Input.GetKeyDown(SpeedKey_Increase))
            changefactor(SpeedFactor_Step);

        transform.Translate(SpaceNavigator.Translation * SpeedFactor, Space.Self);

        if (HorizonLock)
        {
            // This method keeps the horizon horizontal at all times.
            // Perform azimuth in world coordinates.
            transform.Rotate(Vector3.up, SpaceNavigator.Rotation.Yaw() * Mathf.Rad2Deg, Space.World);
            // Perform pitch in local coordinates.
            transform.Rotate(Vector3.right, SpaceNavigator.Rotation.Pitch() * Mathf.Rad2Deg, Space.Self);
        }
        else
        {
            transform.Rotate(SpaceNavigator.Rotation.eulerAngles, Space.Self);
        }
    }
    public void FixedUpdate()
    {
        if (Time.time > TimeToHide && GUI_alpha > 0)
            GUI_alpha -= 0.02f;
    }

    void OnGUI()
    {
        GUI.color = new Color(1, 1, 1, GUI_alpha);
        GUI.Label(new Rect(10, 10, 300, 20), "Speed factor : " + SpeedFactor);
    }

    void changefactor(float coeff)
    {
        SpeedFactor *= coeff;
        SpeedFactor = Mathf.Clamp(SpeedFactor, SpeedFactor_Min, SpeedFactor_Max);
        TimeToHide = Time.time + TimeToShow;
        GUI_alpha = 1;
    }
}
