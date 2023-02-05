using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Triangle_3D : MonoBehaviour
{
    [SerializeField]
    float angle_deg = 45;

    [SerializeField]
    Material material;

    MeshFilter filter;
    MeshRenderer renderer;
    MeshCollider collider;

    void OnValidate()
    {
        if (filter == null) filter = gameObject.GetComponent<MeshFilter>();
        if (filter == null) filter = gameObject.AddComponent<MeshFilter>();

        if (renderer == null) renderer = gameObject.GetComponent<MeshRenderer>();
        if (renderer == null) renderer = gameObject.AddComponent<MeshRenderer>();

        if (collider == null) collider = gameObject.GetComponent<MeshCollider>();
        if (collider == null) collider = gameObject.AddComponent<MeshCollider>();

        //if (material == null) material = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");

        var mesh = CreateTriangle3DMesh(angle_deg);

        filter.sharedMesh = mesh;
        collider.sharedMesh = mesh;

        renderer.sharedMaterial = material;
    }

    static Mesh CreateTriangle3DMesh(float angle_deg)
    {
        float angle_rad = Mathf.Deg2Rad * angle_deg;

        float R = 1f;

        float X = R * Mathf.Sin(angle_rad / 2);
        float X_ = -X;
        float Z = R * Mathf.Cos(angle_rad / 2);

        float E = 0.1f; //Epaisseur

        Vector3 a = new Vector3(0, 0, 0);
        Vector3 b = new Vector3(X_, 0, Z);
        Vector3 c = new Vector3(X, 0, Z);
        Vector3 d = new Vector3(0, E, 0);
        Vector3 e = new Vector3(X_, E, Z);
        Vector3 f = new Vector3(X, E, Z);

        Vector3[] vertices = { a, b, c, d, e, f, };

        Vector2[] uv = {
             Vector3.back,
             Vector3.back,
             Vector3.back,
             Vector3.back,
             Vector3.back,
             Vector3.back,
         };

        int[] triangles = {
            2, 1, 0, //c,b,a
            3, 4, 5, //d,e,f
            0, 1, 3, //a,b,d
            3, 1, 4, //d,b,e
            2, 0, 5, //c,a,f
            5, 0, 3, //f,a,d
            2, 5, 1, //c,f,b
            5, 4, 1  //f,e,b
        };

        var mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.Optimize();

        //Unwrapping.GenerateSecondaryUVSet(mesh);
        //mesh.RecalculateBounds();
        //mesh.RecalculateNormals();
        //mesh.RecalculateTangents();
        return mesh;
    }
}
