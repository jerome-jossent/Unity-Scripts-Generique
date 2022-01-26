using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    // The GameObject to instantiate.
    public GameObject object_to_duplicate;
    public int nbr_lignes = 5;
    public float espacement_horizontal = 0.1f;
    public float aiguille_diametre = 0.1f;
    public bool drawed = false;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        OnDrawGizmosSelected();        
    }

    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying || drawed) { return; }
        dessine();
    }

    void Awake()
    {
        if (drawed) { return; }
        dessine();
    }

    private void dessine()
    {
        drawed = true;
        for (int i = 1; i < nbr_lignes + 1; i++)
        {
            int nbr = (int)(1.0f / espacement_horizontal);
            for (int c = 0; c < nbr + 1; c++)
            {
                GameObject aig = newaiguille();
                float x, y;
                if (pair(i))
                    x = -0.5f + c * espacement_horizontal + espacement_horizontal / 2;
                else
                    x = -0.5f + c * espacement_horizontal;

                y = -i * 0.1f + 0.4f;
                aig.transform.localPosition = new Vector3(x, y, -1);
                aig.name = "Aiguille L" + i + "C" + c;
            }
        }
    }

    bool pair(int nombre)
    {
        if (nombre % 2 == 0)
            return true;
        else
            return false;
    }


    GameObject newaiguille()
    {
        GameObject ins = Instantiate(object_to_duplicate, new Vector3(0, 0, 0), Quaternion.identity, transform);

        float hauteur = aiguille_diametre;

        ins.transform.localScale = new Vector3(aiguille_diametre / transform.localScale.x,
                                                hauteur / transform.localScale.z,
                                                aiguille_diametre / transform.localScale.y);
        ins.transform.Rotate(90, 0, 0);
        
        return ins;
    }


}
