using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab de obstáculo asignado en el Inspector
    public float spawnInterval = 2f;   // Intervalo de tiempo entre intentos de spawn (si es posible)
    public float minLifetime = 3f;     // Tiempo mínimo de vida de un obstáculo
    public float maxLifetime = 7f;     // Tiempo máximo de vida de un obstáculo
    public Vector2 spawnAreaSize = new Vector2(3f, 3f);  // Área de spawn

    private GameObject currentObstacle;  // Referencia al obstáculo actual (si existe)

    private void Start()
    {
        // Iniciar el ciclo de intentos de spawn
        InvokeRepeating("TrySpawnObstacle", 1f, spawnInterval);
    }

    void TrySpawnObstacle()
    {
        // Si ya hay un obstáculo activo, no hacer nada
        if (currentObstacle != null)
        {
            return;
        }

        // Si no hay obstáculo activo, instanciar uno nuevo
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // Asegúrate de que el prefab esté asignado
        if (obstaclePrefab == null)
        {
            Debug.LogError("¡No se ha asignado ningún prefab de obstáculo en el inspector!");
            return;
        }

        // Calcula una posición aleatoria dentro del área de spawn
        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), Random.Range(-spawnAreaSize.y, spawnAreaSize.y));

        // Instancia el prefab de obstáculo en la posición calculada
        currentObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Destruye el obstáculo después de un tiempo aleatorio y restablece la referencia
        float lifetime = Random.Range(minLifetime, maxLifetime);
        Destroy(currentObstacle, lifetime);
        Invoke(nameof(ResetCurrentObstacle), lifetime);
    }

    // Restablecer la referencia al obstáculo actual cuando desaparece
    void ResetCurrentObstacle()
    {
        currentObstacle = null;
    }
}