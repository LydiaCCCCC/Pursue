using UnityEngine;

public class FlipperMove : MonoBehaviour
{
    public HingeJoint2D hinge;
    public float hitSpeed;    
    public float returnSpeed;    
    public float motorTorque;
    public KeyCode controlKey;

    //private float restAngle; 

    private bool isReturning = false;

    

    void Update()
    {
        JointMotor2D motor = hinge.motor;

       
        if (Input.GetKey(controlKey))
        {
            Debug.Log("Key Pressed!");
            motor.motorSpeed = hitSpeed;
            motor.maxMotorTorque = motorTorque;
            hinge.motor = motor;
            hinge.useMotor = true;
            isReturning = false;
        }

        if (Input.GetKeyUp(controlKey)){
            hinge.useMotor = false;

        }

     
       
    }
}


