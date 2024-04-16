using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Variable instantiation
        // Constants
    private const float NORMALIZED_SPEED = 0.707107f;     // 1/sqrt(2)


        // Public
    public float speed;


        // Private

    // Update is called once per frame
    void Update()
    {
        // Get the vertical and horizontal axes.
        // The names for the GetAxis function can be found in Edit > Project Settings > Input Manager.
        // We use this instead of something like GetKey since GetAxis allows the player to edit controls
        // to their liking. They are on a scale from -1 .. 1.
        //
        // Only difference between GetAxis and GetAxisRaw is that GetAxisRaw will immediately snap to the correct value
        // while GetAxis changes in steps of 0.05f.
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");

        
        // Normalize the speeds.
        // Since we only have vertical and horizontal, it is faster just to check if both
        // of them are not 0.
        if (!(verticalSpeed == 0 && verticalSpeed == 0)) {
            verticalSpeed *= NORMALIZED_SPEED;
            horizontalSpeed *= NORMALIZED_SPEED;
        }
        // Shrink it so that we move "speed" units in 1 second
        verticalSpeed *= speed * Time.deltaTime;
        horizontalSpeed *= speed * Time.deltaTime;

        transform.Translate(horizontalSpeed, verticalSpeed, 0);
    }
}
