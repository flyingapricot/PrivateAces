using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTiler : MonoBehaviour
{
    public Sprite backgroundSprite;
    public Vector2 arenaSize;

    [SerializeField]
    public string sortingLayerName = "Default";  // Use string for sorting layer name
    public int orderInLayer = 0;  // Default order in layer

    void Start()
    {
        CreateTiledBackground();
    }

    void CreateTiledBackground()
    {
        GameObject background = new GameObject("TiledBackground");
        background.transform.position = Vector2.zero; // Center the background
        background.transform.SetParent(transform);

        SpriteRenderer renderer = background.AddComponent<SpriteRenderer>();
        renderer.sprite = backgroundSprite;
        renderer.drawMode = SpriteDrawMode.Tiled;
        renderer.size = arenaSize; // Set the size of the tiling area

        // Optionally, adjust the sorting layer if needed
        renderer.sortingLayerName = sortingLayerName;
        renderer.sortingOrder = orderInLayer;
    }
}

