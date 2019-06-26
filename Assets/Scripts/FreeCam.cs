using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCam : MonoBehaviour
{

    public Texture2D cursorIcon;

    Rigidbody rb;

    public float lookSensitivity = 50;
    public float speed = 300f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    bool InMenu = false;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(cursorIcon,Vector2.zero, CursorMode.Auto);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Tab))
        {
            InMenu = !InMenu;
            if(!InMenu) Cursor.lockState = CursorLockMode.Locked;
                else Cursor.lockState = CursorLockMode.None;

            rb.velocity = new Vector3(0, 0, 0);
            rb.angularVelocity = new Vector3(0, 0, 0);
        }
        if (!InMenu)
        {
            rotationX += Input.GetAxis("Mouse X") * lookSensitivity * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * lookSensitivity * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

            rb.velocity = Vector3.zero;

            float speedMult = 1f;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedMult = 1.5f;
            }
            else
            {
                speedMult = 1f;
            }

            rb.velocity += transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed * speedMult;
            rb.velocity += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed * speedMult;
        }
    }
}