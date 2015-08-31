using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class Player : MonoBehaviour
{

    [Header("Input")]
    public string[] Mouse = { "Fire1", "Fire2" };

    bool holding, dragging;
    public float holdSensitivity, dragRadius;

    public bool isDragging
    {
        get
        {
            return (holding && dragging);
        }
        private set { return; }
    }

    public Wheel wheel;

    float s;
    Vector2 pos;

    public new Camera camera
    {
        get
        {
            if (cam == null)
                cam = GetComponent<Camera>();

            return cam;
        }
    }
    Camera cam;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Vector3 pos = camera.ViewportToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Gizmos.DrawWireSphere(pos, 0.25f);
    }

    GameObject Pick()
    {
        Ray pick = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pick.origin, pick.direction);
        if (hit)
        {
            Debug.DrawLine(Vector3.zero, hit.centroid, Color.white, 1f);
            return hit.transform.GetComponent<GameObject>();
        }
        return null;
    }

    GameObject obj;

    void Update()
    {

        if (Input.GetButtonDown(Mouse[0]))
        {
            s = holdSensitivity;
            pos = Input.mousePosition;

            obj = Pick();
        }

        if (Input.GetButton(Mouse[0]))
        {
            float dist = Vector2.Distance(pos, Input.mousePosition);

            if (dist > dragRadius)
                dragging = true;
            else
                dragging = false;

            if (s > 0)
            {
                s -= Time.deltaTime;
                holding = false;
            }
            else
            {
                holding = true;
            }
        }

        if (Input.GetButtonUp(Mouse[0]))
        {
            s = holdSensitivity;
            holding = false;
            dragging = false;
        }

    }

    void OnGUI()
    {
        GUILayout.Label(isDragging.ToString());
        GUILayout.Label((obj == null) ? "None" : obj.ToString());
    }
}
