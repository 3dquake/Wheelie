using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class Player : MonoBehaviour
{

    [Header("Input")]
    public string[] Mouse = { "Fire1", "Fire2" };
    public string[] Tags = { "Clickable" };

    public float holdSensitivity, dragRadius, power;
    public Wheel wheel;

    public Vector2 mousePosition
    {
        get { return camera.ScreenToWorldPoint(Input.mousePosition); }
        private set { return; }
    }
    public bool isDragging
    {
        get
        {
            return (holding && dragging);
        }
        private set { return; }
    }
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

    

    bool holding, dragging, hasWheel;
    float sens;
    Collider2D[] objects;
    Vector2 pos, dir;

    void OnDrawGizmos()
    {
        Gizmos.color = (isDragging) ? Color.green : Color.red;
        Gizmos.DrawWireSphere(mousePosition, 0.25f);
    }

    Collider2D[] Pick()
    {
        return Physics2D.OverlapPointAll(mousePosition);
    }

    void Update()
    {
        
        if (pos != Vector2.zero)
            Debug.DrawLine(pos, mousePosition);

        // HOLDING & DRAGGING
        if (Input.GetButtonDown(Mouse[0]))
        {
            sens = holdSensitivity;
            mousePosition = Input.mousePosition;

            objects = Pick();
            foreach (Collider2D obj in objects)
            {
                if (obj.tag == "Clickable")
                    hasWheel = true;
            }

            pos = mousePosition;
        }

        if (Input.GetButton(Mouse[0]))
        {

            dir = pos - mousePosition;

            float dist = Vector2.Distance(pos, mousePosition);

            if (dist > dragRadius)
                dragging = true;
            else
                dragging = false;

            if (sens > 0)
            {
                sens -= Time.deltaTime;
                holding = false;
            }
            else
            {
                holding = true;
            }
        }

        if (Input.GetButtonUp(Mouse[0]))
        {
            if (hasWheel)
            {
                wheel.rigidbody.AddForce(dir.normalized * -dir.magnitude, ForceMode2D.Impulse);
                wheel.rigidbody.AddTorque((dir.magnitude * power) * dir.normalized.x);
            }
            hasWheel = false;

            FlushMouseInput();
        }
        // HOLDING & DRAGGING
    }

    void FlushMouseInput()
    {
        pos = Vector2.zero;
        sens = holdSensitivity;
        holding = false;
        dragging = false;
    }

}
