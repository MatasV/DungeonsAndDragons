using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public Material mapMaterial;

    [Range(1,10000)]
    public int mapScaleDownAmount = 1000;

    public delegate void OnMapSelect(MapSlot map);
    public static event OnMapSelect onMapSelected;

    public static void MapSelected(MapSlot map)
    {
        onMapSelected?.Invoke(map);
    }

    void Start()
    {
        onMapSelected += BuildMap;
    }

    void BuildMap(MapSlot map)
    {
        Debug.Log("New Map was Selected! It's name: " + map.currentMap.Name + " It's size: x: " + map.currentMap.size.x + " y: " + map.currentMap.size.y
            + " That means I need a plane of size: x: " + map.currentMap.size.x / 1920 + " y: " + map.currentMap.size.y / 1080);
           

        ClearPreviousMap();
        GameObject MapObj = GameObject.CreatePrimitive(PrimitiveType.Plane);
        MapObj.GetComponent<MeshRenderer>().sharedMaterial = mapMaterial;
        mapMaterial.SetTexture("_BaseMap", map.currentMap.texture);
        MapObj.transform.SetParent(transform);
        MapObj.transform.localScale = new Vector3(map.currentMap.size.x / mapScaleDownAmount, 1, map.currentMap.size.y / mapScaleDownAmount);
        MapObj.transform.localRotation = Quaternion.Euler(0, 180, 0); // if I don't rotate, all maps face the other way around from the camera
        MapObj.transform.localPosition = new Vector3(0, 0, 0);
    }

    void ClearPreviousMap()
    {
        if(transform.childCount>0 && transform.GetChild(0)!=null)
            Destroy(transform.GetChild(0).gameObject);
    }
}
