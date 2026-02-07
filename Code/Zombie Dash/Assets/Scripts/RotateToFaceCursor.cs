using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceCursor : MonoBehaviour
{
    public Rigidbody2D rigidBody;  // REFERNCE: Rigid body -> Allows for for a GameObject to react to in game physics
    public Camera cam;             // REFERNCE: Camera
    
    Vector2 positionMouse;

    void Update()
    {
        // Current position of the mouse in *pixel coordinates* (not to be confused with in game world units)
        positionMouse = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    // Physics based logic is placed here. Logic inside this function is independent of FPS.
    void FixedUpdate()
    {
        // Sprite Rotation Calculations
        Vector2 directionLook = positionMouse - rigidBody.position;
        float angle = Mathf.Atan2(directionLook.y, directionLook.x) * Mathf.Rad2Deg - 90f;

        // Rotate Sprite
        rigidBody.rotation = angle;
    }
}
