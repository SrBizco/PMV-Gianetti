using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PowerUpSpawner powerUpSpawner;

    private void Start()
    {
        powerUpSpawner = FindObjectOfType<PowerUpSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            powerUpSpawner.OnPowerUpCollected(gameObject);
        }
    }
}