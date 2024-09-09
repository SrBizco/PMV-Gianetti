using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force = 0.1f;
    private GameManager gm;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = FindObjectOfType<GameManager>();

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Vector2 direction = rb.velocity.normalized;
            rb.AddForce (direction * force, ForceMode2D.Impulse);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Goal"))
        {
            gm.ResetBall();
        }
    }
}