using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement5 : MonoBehaviour
{
     Vector2 pointA = new Vector2(17.5f,2.5f);
     Vector2 pointB = new Vector2(32.5f,2.5f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}