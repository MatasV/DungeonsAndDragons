using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(Image))]

public class MapSlot : MonoBehaviour
{
    public Map currentMap;
    public Image image;

    public TMP_Text nameText;
    public TMP_Text sizeText;
    public void Init(Map map)
    {
        image.enabled = true;
        currentMap = map;
        nameText.text = map.Name;
        sizeText.text = map.texture.width + " x " + map.texture.height;
        image.sprite = Sprite.Create((Texture2D)currentMap.texture, new Rect(0.0f, 0.0f, currentMap.texture.width, currentMap.texture.height),new Vector2(0.5f, 0.5f), 100f);
        Button selectButton = gameObject.AddComponent<Button>();
        selectButton.onClick.AddListener(delegate { SpawnMap.MapSelected(this); });
    }

    void OnValidate()
    {
        image = GetComponentInChildren<Image>();
    }
}
