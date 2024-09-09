using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Collider2D goal1;
    [SerializeField] private Collider2D goal2;
    [SerializeField] private Vector2 initialforce = new Vector2(5, 0);
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           ResetBall();
        }
    }
    public void ResetBall()
    {
        ball.transform.position = Vector2.zero;
        ball.rb.velocity = Vector2.zero;
        ball.rb.AddForce(initialforce);
    }
}
