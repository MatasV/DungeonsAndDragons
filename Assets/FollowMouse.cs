using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float speed = 10f;
     public Vector3 targetPos;
     public bool isMoving;
     const int MOUSE = 0;
     // Use this for initialization1
     void Start () {
 
         targetPos = transform.position;
     }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(MOUSE))
        {
            SetTarggetPosition();
            MoveObject();
            ShowTile();
        }
    }
    void SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
        {
            

            targetPos = ray.GetPoint(point);
        }
        
        targetPos = new Vector3(targetPos.x, 5, targetPos.z);

    }
    void MoveObject()
    { 
        transform.position = targetPos;
        Debug.DrawLine(transform.position, targetPos, Color.red);

    }

    void ShowTile()
    {
        float width = GetComponent<Renderer>().bounds.size.x;
        float height = GetComponent<Renderer>().bounds.size.y;
        float depth = GetComponent<Renderer>().bounds.size.z;
        //Plane plane = new Plane(Vector3.down, transform.position);
        Debug.DrawRay(transform.position, Vector3.down * 10 );
        Vector3 bottomMiddle = transform.position;
        bottomMiddle.y -= height/2;

        RaycastHit hit;

        Material hitMat;
        Physics.Raycast(bottomMiddle, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity); //add the mask to only target tiles
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);

                var block = new MaterialPropertyBlock();
                block.SetColor("_BaseColor", Color.green);
                hit.transform.GetComponent<MeshRenderer>().SetPropertyBlock(block);

                
                
            }

        }


    }

}


