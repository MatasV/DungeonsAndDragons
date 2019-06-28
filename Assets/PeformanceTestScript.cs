using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeformanceTestScript : MonoBehaviour
{
    [SerializeField]
    private int amountOfTilesZ;
    [SerializeField]
    public int AmountOfTilesZ
    {
        get { return amountOfTilesZ; }
        set
        {
            amountOfTilesZ = value;
            GenerateMap();
        }
    }
    [SerializeField]
    private int amountOfTilesX;
    [SerializeField]
    public int AmountOfTilesX
    {
        get
        {
            return amountOfTilesX;
        }
        set
        {
            amountOfTilesX = value;
            GenerateMap();
        }
    }

    public Material materialToAdd;
    void Start()
    {
        GenerateMap();
    }
    void ClearTiles()
    {
        Transform[] tiles;
        tiles = GetComponentsInChildren<Transform>();
        for (int i = 0; i < tiles.Length; i++)
        {
            Destroy(tiles[i]);
        }
    }
    public void CreateMap()
    {
        ClearTiles();
        GenerateMap();
    }
    public void GenerateMap()
    {
       

        for (int i = 0; i < AmountOfTilesX; i++)
        {
            for (int j = 0; j < AmountOfTilesZ; j++)
            {
                GameObject MapObj = GameObject.CreatePrimitive(PrimitiveType.Plane);
                MeshRenderer renderer = MapObj.GetComponent<MeshRenderer>();
                //renderer.enabled = false;
                MapObj.transform.SetParent(transform);
                MapObj.transform.localScale = new Vector3((float)1/(float)AmountOfTilesX, 1, (float)1 / (float)AmountOfTilesZ);
                MapObj.gameObject.name = i + " : 0 :" + j;
                MapObj.transform.localRotation = Quaternion.Euler(0, 0, 0); // if I don't rotate, all maps face the other way around from the camera
                MapObj.transform.localPosition = new Vector3((float)10 / (float)AmountOfTilesZ * i, 0, (float)10 / (float)AmountOfTilesZ * j);
                MapObj.GetComponent<MeshCollider>().convex = true;
                renderer.material = materialToAdd;
            }
        }
    
    }
}
