using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyCollider))]
public class PolyRenderer : MonoBehaviour {

    PolyCollider poly;
    MeshRenderer renderer;
    MeshFilter filter;

    Mesh Mesh;
    Material material;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();
        poly = GetComponent<PolyCollider>();

        SetVerts();
    }

    void SetVerts()
    {
        if (Mesh == null)
            Mesh = new Mesh();
        else
            Mesh.Clear();

        Mesh.vertices = new Vector3[poly.collider.points.Length];

        //Copy vert points from poly
        for (int i = 0; i < Mesh.vertices.Length; i++)
        {
            Mesh.vertices[i] = poly.collider.points[i];
        }

        Mesh.triangles 

        Mesh.name = "GeneratedMesh";
        Mesh.Optimize();

        filter.mesh = Mesh;

    }

    void Update()
    {
        
    }

}
