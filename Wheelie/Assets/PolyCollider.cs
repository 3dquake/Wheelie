using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D))]
public class PolyCollider : MonoBehaviour {

    public new PolygonCollider2D collider
    {
        get
        {
            if (coll == null)
                coll = GetComponent<PolygonCollider2D>();

            return coll;
        }
    }
    PolygonCollider2D coll;

    public bool drawVerts, drawEdges;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < collider.points.Length; i++)
        {
            if (drawVerts)
            Gizmos.DrawWireSphere((Vector2)transform.position + collider.points[i], 0.01f);

            if (drawEdges)
            {
                if (i == collider.points.Length - 1)
                    Gizmos.DrawLine((Vector2)transform.position + collider.points[i], (Vector2)transform.position + collider.points[0]); //Last point -> first point
                else
                    Gizmos.DrawLine((Vector2)transform.position + collider.points[i], (Vector2)transform.position + collider.points[i + 1]); //Current point -> Next point
            }
        }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
}
