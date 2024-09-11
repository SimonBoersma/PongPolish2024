using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject ball;
    private void Start()
    {
        ball = FindFirstObjectByType<BallMovement>().gameObject; //Hij zoekt naar de eerste object die de Ballmovement script heeft en zet het in de gameobject
        ball.AddComponent<PlayerScoreZoom>(); //De script PlayerScoreZoom staat nu op de ball
    }
}
