using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSecurityCamera : MonoBehaviour
{
    public float angleA = 0; 
    public float angleB = 100; 
    public float rotationSpeed = 1.0f; 
    private bool movingToEnd = true; 
    public float waitTime ; 
    private float waitCounter = 0;

    void Update()
    {
        if (waitCounter <= 0)
        {
            if (movingToEnd)
            {
                RotateTowards(angleB);
            }
            else
            {
                RotateTowards(angleA);
            }
        }
        else
        {

            waitCounter -= Time.deltaTime;
        }
    }

    void RotateTowards(float targetAngle)
    {
        float currentAngle = transform.eulerAngles.z;
        float Rotation = Mathf.MoveTowardsAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(0, 0, Rotation);


        if (Mathf.Abs(Rotation - targetAngle) < 0.1) 
        {
            waitCounter = waitTime; 
            movingToEnd = !movingToEnd; 
        }
    }


    void OnDrawGizmos()
    {

            Vector3 directionA = Quaternion.Euler(0, 0, angleA) * Vector3.right;
            Gizmos.color = Color.blue; 
            Gizmos.DrawLine(transform.position, transform.position + directionA * 10);


            Vector3 directionB = Quaternion.Euler(0, 0, angleB) * Vector3.right;
            Gizmos.color = Color.yellow; 
            Gizmos.DrawLine(transform.position, transform.position + directionB * 10); 
    }

}

