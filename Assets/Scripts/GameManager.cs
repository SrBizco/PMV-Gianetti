using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Collider2D goal1;
    [SerializeField] private Collider2D goal2;
    [SerializeField] private Vector2 initialforce = new Vector2(5, 0);
    [SerializeField] private PlayerController player1;
    [SerializeField] private PlayerController player2;
    [SerializeField] private UI uiManager;

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

    public void ActivatePowerUp(GameObject powerUp, GameObject lastPlayerHit)
    {
        if (powerUp.CompareTag("PowerUpSize"))
        {
            if (lastPlayerHit != null)
            {
                PlayerController player = lastPlayerHit.GetComponent<PlayerController>();
                if (player != null)
                {
                    player.IncreaseSize(); 
                }
            }
        }
        else if (powerUp.CompareTag("PowerUpSpeed"))
        {
            ball.rb.velocity *= 1.5f; 
        }
    }
    public void OnGoalScoredP1()
    {
       uiManager.UpdatePlayer1Score();
    }
    public void OnGoalScoredP2()
    {
        uiManager.UpdatePlayer2Score();
    }
}