using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 45f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public float maxMotorTorque = 120f; 
    public float maxBrakeTorque = 250f;
    public float currentSpeed;      
    public float maximumSpeed = 200f; 
    public bool isBraking = false;   

    private List<Transform> nodes;
    private int currentNode = 0;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for(int i = 0; i < pathTransforms.Length; i++)
        {
            if(pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        currentSpeed = 2 * Mathf.PI * wheelFL.radius *wheelFL.rpm * 60/100; 

        if (isBraking)
        {
            Braking();
        } else {
            ApplySteer();
            Drive();
            CheckWayPointDistance();
        }

    }

    private void ApplySteer() 
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;
    }

    private void Drive() 
    {
        if( currentSpeed < maximumSpeed && !isBraking) {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;   
        } else {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }

    private void CheckWayPointDistance()
    { 
        print(currentNode);
        if(Vector3.Distance(transform.position, nodes[currentNode].position) < 10f ) {
            if(currentNode == nodes.Count - 1)  {
                isBraking = true;
            } else {
                currentNode++;
            }
        }
    }

    private void Braking() 
    {
        if ( isBraking ) {
            wheelFL.brakeTorque = maxBrakeTorque;
            wheelFR.brakeTorque = maxBrakeTorque;

            if ( currentSpeed == 0) {
                enabled = false; //disable script
            //wheelFL.brakeTorque = 0;
            //wheelFR.brakeTorque = 0;
            }
        }
    }
}
