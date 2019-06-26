using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public GameObject mapSlotObj;
    [SerializeField]
    List<MapSlot> totalMapSlots;
    [SerializeField]
    List<MapSlot> currentMapSlots;

    public Transform parent;
    void Awake()
    {
        totalMapSlots = new List<MapSlot>();
    }
    public void DisplayMaps(List<Map> mapToDisplay)
    {
        ClearMapSlots();
        currentMapSlots = new List<MapSlot>();
        foreach (Map map in mapToDisplay)
        {
            MapSlot mapSlot = Instantiate(mapSlotObj, parent.transform).GetComponent<MapSlot>();
            mapSlot.Init(map);
            currentMapSlots.Add(mapSlot);
            totalMapSlots.Add(mapSlot);
        }
    }
    void ClearMapSlots()
    {
        MapSlot[] slots = GetComponentsInChildren<MapSlot>();
        for (int i = 0; i < slots.Length; i++)
        {
            Destroy(slots[i].gameObject);
        }
        if(currentMapSlots !=null && currentMapSlots.Count>0)
            currentMapSlots.Clear();
    }
    void OnValidate()
    {
        if(mapSlotObj == null && GetComponentInChildren<MapSlot>()!=null)
            mapSlotObj = GetComponentInChildren<MapSlot>().gameObject;
    }
}
