using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBoundary : MonoBehaviour
{
    public float width = 10f;
    public float height = 10f;
    public float thickness = 0.5f; // Thickness of each boundary wall
    public Sprite wallSprite; // Sprite for the wall

    [SerializeField]
    public string sortingLayerName = "Default";  // Use string for sorting layer name
    public int orderInLayer = 0;  // Default order in layer

    private void Start()
    {
        CreateBoundary();
    }

    private void CreateBoundary()
    {
        // Remove existing walls (if any)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // Create top boundary
        CreateWall("Top Wall", new Vector2(0, height / 2), new Vector2(width + thickness * 2, thickness));
        // Create bottom boundary
        CreateWall("Bottom Wall", new Vector2(0, -height / 2), new Vector2(width + thickness * 2, thickness));
        // Create left boundary
        CreateWall("Left Wall", new Vector2(-width / 2, 0), new Vector2(thickness, height + thickness * 2));
        // Create right boundary
        CreateWall("Right Wall", new Vector2(width / 2, 0), new Vector2(thickness, height + thickness * 2));
    }

    private void CreateWall(string name, Vector2 position, Vector2 size)
    {
        GameObject wall = new GameObject(name);
        wall.transform.SetParent(transform);
        wall.transform.localPosition = position;
        wall.transform.localRotation = Quaternion.identity;

        // Add SpriteRenderer
        SpriteRenderer renderer = wall.AddComponent<SpriteRenderer>();
        renderer.sprite = wallSprite;
        renderer.color = Color.gray; // Customize as needed
        renderer.drawMode = SpriteDrawMode.Tiled; // Set to Tiled mode
        renderer.size = size; // This now tiles the sprite to fill this size
        renderer.sortingLayerName = sortingLayerName;
        renderer.sortingOrder = orderInLayer;

        // Add BoxCollider2D or BoxCollider
        if (wallSprite) // Assuming 2D setup
        {
            BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
            collider.size = size;
        }
        else // For 3D setup
        {
            BoxCollider collider = wall.AddComponent<BoxCollider>();
            collider.size = new Vector3(size.x, size.y, 1); // Assuming depth of 1 for 3D
        }
    }
}
