using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement3 : MonoBehaviour
{
     Vector2 pointA = new Vector2(-6.687105f,3.817317f);
     Vector2 pointB = new Vector2(-6.687105f,-1.18f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}
