using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class Finish : MonoBehaviour
{

    public new Collider2D collider
    {
        get
        {
            if (coll == null)
                coll = GetComponent<Collider2D>();

            return coll;
        }
    }
    Collider2D coll;

    public bool hasWon;
    public ParticleSystem effect;

    void Awake()
    {
        if (effect != null)
        {
            effect.Stop();
        }
    }

    bool b = true;

    void Update()
    {
        if (!collider.isTrigger)
        {
            Debug.LogWarning(name + " is not a trigger!");
            gameObject.SetActive(false);
        }

        if (effect != null && hasWon && b)
        {
            b = false;
            effect.Play();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wheel>() != null)
        {
            hasWon = true;
        }
    }
}
