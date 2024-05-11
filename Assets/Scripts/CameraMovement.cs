using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 0, 0);  // Default offset to maintain a typical distance from the player in 2D games

    void LateUpdate()
    {
        // Ensure the camera follows the player's position with the specified offset
        transform.position = player.position + offset;
    }
}