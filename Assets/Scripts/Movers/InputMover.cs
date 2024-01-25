using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction moveHorizontal = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction moveVertical  = new InputAction(type: InputActionType.Button);


    void OnEnable()  {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()  {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    public void SetSpeed(float velocity)
    {
        this.speed = velocity;
    }
    
    public float GetSpeed()
    {
        return speed;
    }

    void Update() {
        float horizontal = moveHorizontal.ReadValue<float>();
        float vertical = moveVertical.ReadValue<float>();
        float rotateHor = horizontal * -90;
        float rotateVer = vertical * -180;
        
      //  Debug.Log("HOR: " + horizontal + " Vert: " + vertical);
        
        Vector3 movementVector = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
        transform.position += movementVector;

        // Player moves up
        if (vertical == 1f)
        {
            return;
        }
        
        // Rotate object accordingly
        Quaternion targetRot = Quaternion.Euler(0, 0, rotateHor + rotateVer);
        transform.rotation = targetRot;
    }
}