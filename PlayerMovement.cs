using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
public class PlayerMovement : MonoBehaviour
{   //
    InputManager inputmanager;
    Vector3 MoveDirection;
    Transform cameraObject;
    Rigidbody playerrb;
    public float movementspeed = 7;
    public float rotationspeed = 15;
    private void Awake()
    {   //variable gets the component input manager
        inputmanager = GetComponent<InputManager>();
        playerrb = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }
    public void handleallmovement()
    {
        handlemovement();
        handlerotation();
    }
    private void handlemovement()
    {
        MoveDirection = cameraObject.forward * inputmanager.VerticalInput;
        //move direction receives the camera moving for right.
        MoveDirection = MoveDirection + cameraObject.right * inputmanager.HorizontalInput;
        MoveDirection.Normalize();
        MoveDirection.y = 0;
        MoveDirection = MoveDirection * movementspeed;

        Vector3 movementvelocity = MoveDirection;
        playerrb.velocity = movementvelocity;
    }
    //Mouse
   
    //Mouse
    private void handlerotation()
    {
        Vector3 targetdirection = Vector3.zero;

        targetdirection = cameraObject.forward * inputmanager.VerticalInput;
        targetdirection = targetdirection + cameraObject.right * inputmanager.HorizontalInput;
        targetdirection.Normalize();
        targetdirection.y = 0;

        Quaternion targetrotation = Quaternion.LookRotation(targetdirection);
        Quaternion playerrotation = Quaternion.Slerp(transform.rotation, targetrotation, rotationspeed * Time.deltaTime);

        transform.rotation = playerrotation;
    }

}
