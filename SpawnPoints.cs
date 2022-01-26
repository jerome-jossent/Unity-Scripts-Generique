using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject QUOI;
    public KeyCode[] COMMENT;
    public GameObject[] OU;
    
    void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown)
        {
            for (int i = 0; i < COMMENT.Length; i++)
            {
                if (COMMENT[i] != KeyCode.None && Event.current.keyCode == COMMENT[i])
                {
                    // téléportation
                    QUOI.transform.position = OU[i].transform.position;
                    break;
                }
            }
        }
    }
}