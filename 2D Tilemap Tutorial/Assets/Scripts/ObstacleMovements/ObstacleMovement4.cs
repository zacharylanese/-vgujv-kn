using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement4 : MonoBehaviour
{
     Vector2 pointA = new Vector2(2.352895f,-1.152683f);
     Vector2 pointB = new Vector2(2.352895f,3.78f);
     void Update()
     {
         transform.position = Vector2.Lerp(pointA, pointB, Mathf.PingPong(Time.time, 1));
     }
}
