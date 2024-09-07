using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
   private float horizontalInput;
   private float verticalInput;
   private float currentBreakForce;
   private float currentSteerAngle;
   private bool isBreaking;

   [SerializeField] private float motorForce;
   [SerializeField] private float breakForce;
   [SerializeField] private float maxSteeringAngle;

   [SerializeField] private WheelCollider frontLeftWheelCollider;
   [SerializeField] private WheelCollider frontRightWheelCollider;
   [SerializeField] private WheelCollider backLeftWheelCollider;
   [SerializeField] private WheelCollider backRightWheelCollider;

   [SerializeField] private Transform frontLeftWheelTransform;
   [SerializeField] private Transform frontRightWheelTransform;
   [SerializeField] private Transform backLeftWheelTransform;
   [SerializeField] private Transform backRightWheelTransform;
   
   private void FixedUpdate()
   {
      GetInput();
      HandleMotor();
      HandleSteering();
      UpdateWheels();
   }

   private void GetInput()
   {
      horizontalInput = Input.GetAxis("Horizontal");
      verticalInput = Input.GetAxis("Vertical");
      isBreaking = Input.GetKey(KeyCode.Space);
   }

   private void HandleMotor()
   {
      frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
      frontRightWheelCollider.motorTorque = verticalInput * motorForce;
      currentBreakForce = isBreaking ? breakForce : 0f;
      if (isBreaking)
      {
         ApplyBreaking();
      }
   }

   private void ApplyBreaking()
   {
      frontLeftWheelCollider.brakeTorque = currentBreakForce;
      frontRightWheelCollider.brakeTorque = currentBreakForce;
      backLeftWheelCollider.brakeTorque = currentBreakForce;
      backRightWheelCollider.brakeTorque = currentBreakForce;
   }

   private void HandleSteering()
   {
      currentSteerAngle = maxSteeringAngle * horizontalInput;
      frontLeftWheelCollider.steerAngle = currentSteerAngle;
      frontRightWheelCollider.steerAngle = currentSteerAngle;
   }

   private void UpdateWheels()
   {
      UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
      UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
      UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
      UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
   }

   private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
   {
      Vector3 pos;
      Quaternion rot;
      wheelCollider.GetWorldPose(out pos, out rot);
      wheelTransform.rotation = rot;
      wheelTransform.position = pos;
   }

    public void die()
    {
        //TODO: might need to add more
       gameObject.SetActive(false);
    }
}

