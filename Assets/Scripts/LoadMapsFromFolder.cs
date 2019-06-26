using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    public string Name;
    public Texture texture;
    public Vector2 size;

    public Map(string _name, Texture _texture, Vector2 _size)
    {
        Name = _name;
        texture = _texture;
        size = _size;
    }


}
public class LoadMapsFromFolder : MonoBehaviour
{
    [SerializeField]
    private List<Map> Maps;
    [Space]
    [SerializeField]
    bool SendToDisplays = false;
    [SerializeField]
    public MapDisplay[] MapDisplayPanels;
    // Start is called before the first frame update
  //  void OnValidate()
  //  {
     //   LoadMaps();
       
   // }

    void LoadMaps()
    {
        Maps = new List<Map>();
        Texture[] textures = (Texture[])Resources.LoadAll<Texture>("Maps");
        foreach (Texture texture in textures)
        {
            Maps.Add(new Map(texture.name, texture, new Vector2(texture.width, texture.height)));
        }
    }
    void Start()
    { 
        LoadMaps();
        if (SendToDisplays)
        {
            foreach (MapDisplay mapDisplay in MapDisplayPanels)
            {
                mapDisplay.DisplayMaps(Maps); //Event?
            }
        }
    }

}