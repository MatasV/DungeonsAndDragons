using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeformanceTestScript : MonoBehaviour
{
    private int amountOfTilesZ;
    public int AmountOfTilesZ
    {
        get { return amountOfTilesZ; }
        set
        {
            amountOfTilesZ = value;
            Debug.Log(generateTiles());
        }
    }
    private int amountOfTilesX;
    public int AmountOfTilesX
    {
        get
        {
            return amountOfTilesX;
        }
        set
        {
            amountOfTilesX = value;
            Debug.Log(generateTiles());
        }
    }
    public bool generateTiles()
    {
        bool Generated = false;

        for (int i = 0; i < AmountOfTilesX; i++)
        {
            for (int j = 0; j < AmountOfTilesZ; j++)
            {
                GameObject MapObj = GameObject.CreatePrimitive(PrimitiveType.Plane);
                MeshRenderer renderer = MapObj.GetComponent<MeshRenderer>();
                renderer.enabled = false;
                MapObj.transform.SetParent(transform);
                MapObj.transform.localScale = new Vector3(map.currentMap.size.x / mapScaleDownAmount, 1, map.currentMap.size.y / mapScaleDownAmount);
                MapObj.transform.localRotation = Quaternion.Euler(0, 180, 0); // if I don't rotate, all maps face the other way around from the camera
                MapObj.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
        return Generated;
    }
}
