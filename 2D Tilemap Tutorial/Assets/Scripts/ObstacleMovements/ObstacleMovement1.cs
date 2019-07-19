using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement1 : MonoBehaviour
{
     Vector2 pointA = new Vector2(-3.61f,-1.15f);
     Vector2 pointB = new Vector2(-3.61f,3.78f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}