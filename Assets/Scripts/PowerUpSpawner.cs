using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject powerUpSizePrefab;
    [SerializeField] private GameObject powerUpSpeedPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 10f;

    private GameObject activePowerUp;

    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 0f, spawnInterval);
    }

    private void SpawnPowerUp()
    {
        if (activePowerUp != null)
        {
            activePowerUp.SetActive(false);
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject powerUpPrefab = Random.value > 0.5f ? powerUpSizePrefab : powerUpSpeedPrefab;

        if (powerUpPrefab == null)
        {
            Debug.LogError("El prefab de power-up está asignado como null. Asegúrate de asignar los prefabs en el Inspector.");
            return;
        }

        activePowerUp = Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);
        activePowerUp.SetActive(true);
    }

    public void OnPowerUpCollected(GameObject collectedPowerUp)
    {
        
        if (collectedPowerUp != null)
        {
            Destroy(collectedPowerUp); 
        }
    }
}