using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // When Input.GetAxisRaw("Horizontal") is called, it checks the current state of the input devices associated with the "Horizontal" axis:
        // If you press 'D' or the right arrow key, or push a joystick to the right, it returns 1.
        // If you press 'A' or the left arrow key, or push a joystick to the left, it returns -1.
        // If there is no input or the joystick is in the neutral position along the horizontal axis, it returns 0.

        float horizontal_movement = Input.GetAxisRaw("Horizontal");
        float vertical_movement = Input.GetAxisRaw("Vertical");

        // The movement is multiplied by a speed factor and Time.deltaTime to make sure it's smooth and frame-rate independent.

        transform.Translate(horizontal_movement * speed * Time.deltaTime * Vector2.right);
        transform.Translate(vertical_movement * speed * Time.deltaTime * Vector2.up);
    }
}
