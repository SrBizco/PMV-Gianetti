using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 0.1f;
    private GameManager gm;
    public Rigidbody2D rb;
    private GameObject lastPlayerHit; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            lastPlayerHit = other.gameObject; 
            Vector2 direction = rb.velocity.normalized;
            rb.AddForce(direction * force, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Goal1"))
        {
            gm.OnGoalScoredP1();
            gm.ResetBall();
        }
        else if (other.CompareTag("Goal2"))
        {
            gm.OnGoalScoredP2();
            gm.ResetBall();
        }
        else if (other.CompareTag("PowerUpSize") || other.CompareTag("PowerUpSpeed"))
        {
            
            gm.ActivatePowerUp(other.gameObject, lastPlayerHit);
            Destroy(other.gameObject); 
        }
    }

    public GameObject GetLastPlayerHit()
    {
        return lastPlayerHit;
    }
}