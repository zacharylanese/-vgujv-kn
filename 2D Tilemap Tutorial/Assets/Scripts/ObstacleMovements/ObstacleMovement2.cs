using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement2 : MonoBehaviour
{
     Vector2 pointA = new Vector2(-0.6271049f,3.817317f);
     Vector2 pointB = new Vector2(-0.6271049f,-1.15f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}
