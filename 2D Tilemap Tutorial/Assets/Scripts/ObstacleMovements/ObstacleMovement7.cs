using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement7 : MonoBehaviour
{
     Vector2 pointA = new Vector2(3.5f,4.5f);
     Vector2 pointB = new Vector2(3.5f,-4.5f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}
