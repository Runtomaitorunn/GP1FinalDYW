using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLightMovementYellow : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    public bool movingToEnd= true;

    private void Update()
    {
        if (movingToEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, speed*Time.deltaTime);
            if(Vector2.Distance(transform.position, endPoint.position) < 0.1f)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPoint.position) < 0.1f)
            {
                movingToEnd = true;
            }
        }
    }
    private void OnDrawGizmos()
    {
        // Set the color of the Gizmos
        Gizmos.color = Color.yellow;

        // Draw a sphere at the start point with radius 2
        Gizmos.DrawWireSphere(startPoint.position, 2);

        // Draw a sphere at the end point with radius 2
        Gizmos.DrawWireSphere(endPoint.position, 2);

    }
}
