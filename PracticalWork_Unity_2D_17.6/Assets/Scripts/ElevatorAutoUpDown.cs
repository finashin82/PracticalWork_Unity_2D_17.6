using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAutoUpDown : MonoBehaviour
{
    private SliderJoint2D elevatorMovement;
    
    private bool isElevatorPermissionMoveDown = false;
    private bool isElevatorPermissionMoveUp = false;

    private float elevatorSpeedDown = -2f;
    private float elevatorSpeedUp = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        elevatorMovement = GetComponent<SliderJoint2D>();
        
        elevatorMovement.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isElevatorPermissionMoveDown)
        {          
            MotionElevator(elevatorSpeedDown);
            isElevatorPermissionMoveDown = false; 
        }
        
        if (isElevatorPermissionMoveUp)
        {          
            MotionElevator(elevatorSpeedUp);
            isElevatorPermissionMoveUp = false;
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ElevatorMoveUp"))
        {
            isElevatorPermissionMoveUp = true;
        }

        if (collision.CompareTag("ElevatorMoveDown"))
        {
            isElevatorPermissionMoveDown = true;
        }
    }

    /// <summary>
    /// Движение лифта (Направление движения лифта зависит от скорости)
    /// </summary>
    /// <param name="speed"></param>
    private void MotionElevator(float speed)
    {
        var elevatorMotor = elevatorMovement.motor;
        elevatorMotor.motorSpeed = speed;

        elevatorMovement.motor = elevatorMotor;
    }
}
