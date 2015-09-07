using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolyCollider))]
public class PolyRenderer : MonoBehaviour {

    PolyCollider poly;
    new MeshRenderer renderer;
    MeshFilter filter;

    Mesh Mesh;
    //Material Material;

    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
        filter = GetComponent<MeshFilter>();
        poly = GetComponent<PolyCollider>();

        SetVerts();
    }

    const string meshName = "GeneratedMesh";

    [ColorUsage(true)]
    public Color GizmosColor;

    public bool drawVerts, drawEdges;

    

    Vector3[,] edges; //2D array (X, Y)
    Vector3[] verts, tris;

    void OnDrawGizmos()
    {
        /*////*/
        Gizmos.color = GizmosColor;
        if (Mesh.vertices != null)
        {
            for (int i = 0; i < Mesh.vertices.Length; i++)
            {
                if (drawVerts)
                    Gizmos.DrawWireSphere(transform.position + Mesh.vertices[i], 0.01f);

                if (drawEdges)
                {
                    if (i == Mesh.vertices.Length - 1)
                        Gizmos.DrawLine(transform.position + Mesh.vertices[i], transform.position + Mesh.vertices[0]); //Last point -> first point
                    else
                        Gizmos.DrawLine(transform.position + Mesh.vertices[i], transform.position + Mesh.vertices[i + 1]); //Current point -> Next point
                }
            }
        }
        Gizmos.color = Color.white;
        /*////*/
    }

    void SetVerts()
    {
        if (Mesh == null)
            Mesh = new Mesh();
        else
            Mesh.Clear();

        verts = new Vector3[poly.collider.points.Length];

        //Copy vert points from poly
        for (int i = 0; i < Mesh.vertices.Length; i++)
        {
            verts[i] = poly.collider.points[i];
            if (i == verts.Length - 1)
                edges[i, 0];
            else
                edges[i, i + 1];
        }
        
        Mesh.name = meshName;
        Mesh.RecalculateBounds();
        Mesh.RecalculateNormals();

        filter.mesh = Mesh;

    }

    void Update()
    {
        
    }

}
