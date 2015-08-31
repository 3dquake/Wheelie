using UnityEngine;
using System.Collections;

public class Zone : MonoBehaviour
{

    public string zonename;

    //public void OnTriggerStay2D(Collider2D collision)
    //{

    //}

    //public void OnTriggerExit2D(Collider2D collision)
    //{
    //    System.Predicate<string> zone = (string s) => { return zonename == zonename; };
    //    collision.GetComponent<ZoneAgent>().zones.RemoveAll(zonename);
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ZoneAgent za = collision.GetComponent<ZoneAgent>();
        if (!za.zones.Contains(zonename))
            za.zones.Add(zonename);
    }

}
