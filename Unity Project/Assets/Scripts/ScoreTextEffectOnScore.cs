using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextEffectOnScore : MonoBehaviour
{
    private GameObject rightWall;
    private GameObject leftWall;
    private GameObject ball;
    private TMP_Text player1Text;
    private TMP_Text player2Text;
    void Start()
    {
        ball = FindFirstObjectByType<GameObject>();
        rightWall = GameObject.FindGameObjectWithTag("BoundRight");
        leftWall = GameObject.FindGameObjectWithTag("BoundLeft");
        player1Text = GameObject.Find("Player1Score").GetComponent<TMP_Text>();
        player2Text = FindFirstObjectByType<TMP_Text>();
    }

    void Update()
    {
        CollisionCheck();
    }

    private void CollisionCheck()
    {
        CircleCollider2D ballCollider = ball.GetComponent<CircleCollider2D>();
        Collider2D rightWallCollider = rightWall.GetComponent<Collider2D>();
        Collider2D leftWallCollider = leftWall.GetComponent<Collider2D>();
        if (!ballCollider.IsTouching(rightWallCollider) && !ballCollider.IsTouching(leftWallCollider))
        {
            return;
        }
        if (ballCollider.IsTouching(rightWallCollider))
        {
            StartCoroutine(TextChange(player1Text));
        }
        else if (ballCollider.IsTouching(leftWallCollider))
        {
            StartCoroutine(TextChange(player2Text));
        }
    }

    IEnumerator TextChange(TMP_Text text)
    {
        text.fontSize = 100;
        text.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        text.color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        text.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        text.color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        text.color = Color.white;
        text.fontSize = 50;
    }
}
