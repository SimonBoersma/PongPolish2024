using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailHandeler : MonoBehaviour
{
    GameObject ball;

    void Start()
    {
        ball = FindFirstObjectByType<BallMovement>().gameObject;
        TrailRenderer trail = ball.AddComponent<TrailRenderer>();

        trail.time = 0.5f; 
        trail.startWidth = 0.2f;
        trail.endWidth = 0.05f;

        trail.material = new Material(Shader.Find("Sprites/Default")); 

        trail.startColor = Color.yellow; 
        trail.endColor = Color.red; 
    }
}
