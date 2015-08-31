using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Wheel : MonoBehaviour {

    public new Rigidbody2D rigidbody
    {
        get
        {
            if (rbody == null)
                rbody = GetComponent<Rigidbody2D>();

            return rbody;
        }
    }
    Rigidbody2D rbody;

    public new CircleCollider2D collider
    {
        get
        {
            if (coll == null)
                coll = GetComponent<CircleCollider2D>();

            return coll;
        }
    }
    CircleCollider2D coll;
    
}
