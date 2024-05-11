using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOfTrees : MonoBehaviour
{
    public GameObject treePrefab;  // Drag your tree prefab here in the inspector
    public int width = 10;
    public int height = 10;
    public float spacing = 1;  // Space between trees

    [SerializeField]
    public string sortingLayerName = "Default";  // Use string for sorting layer name
    public int orderInLayer = 0;  // Default order in layer

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Calculate the offset to start from the middle
        float offsetX = (width - 1) * (1 + spacing) / 2;
        float offsetY = (height - 1) * (1 + spacing) / 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Calculate the position
                Vector3 position = new Vector3(x * (1 + spacing) - offsetX, y * (1 + spacing) - offsetY, 0);

                // Check if the position is (0,0) and skip creating a tree
                if (position == Vector3.zero)
                {
                    continue;  // Skip the rest of the current loop iteration
                }

                // Instantiate the tree at the calculated position
                GameObject tree = Instantiate(treePrefab, position, Quaternion.identity, transform);
                SpriteRenderer renderer = tree.GetComponent<SpriteRenderer>();
                if (renderer != null)
                {
                    renderer.sortingLayerName = sortingLayerName;
                    renderer.sortingOrder = orderInLayer;
                }
            }
        }
    }
}

