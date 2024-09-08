using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;  // Prefab de obst�culo asignado en el Inspector
    public float spawnInterval = 2f;   // Intervalo de tiempo entre intentos de spawn (si es posible)
    public float minLifetime = 3f;     // Tiempo m�nimo de vida de un obst�culo
    public float maxLifetime = 7f;     // Tiempo m�ximo de vida de un obst�culo
    public Vector2 spawnAreaSize = new Vector2(3f, 3f);  // �rea de spawn

    private GameObject currentObstacle;  // Referencia al obst�culo actual (si existe)

    private void Start()
    {
        // Iniciar el ciclo de intentos de spawn
        InvokeRepeating("TrySpawnObstacle", 1f, spawnInterval);
    }

    void TrySpawnObstacle()
    {
        // Si ya hay un obst�culo activo, no hacer nada
        if (currentObstacle != null)
        {
            return;
        }

        // Si no hay obst�culo activo, instanciar uno nuevo
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        // Aseg�rate de que el prefab est� asignado
        if (obstaclePrefab == null)
        {
            Debug.LogError("�No se ha asignado ning�n prefab de obst�culo en el inspector!");
            return;
        }

        // Calcula una posici�n aleatoria dentro del �rea de spawn
        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), Random.Range(-spawnAreaSize.y, spawnAreaSize.y));

        // Instancia el prefab de obst�culo en la posici�n calculada
        currentObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Destruye el obst�culo despu�s de un tiempo aleatorio y restablece la referencia
        float lifetime = Random.Range(minLifetime, maxLifetime);
        Destroy(currentObstacle, lifetime);
        Invoke(nameof(ResetCurrentObstacle), lifetime);
    }

    // Restablecer la referencia al obst�culo actual cuando desaparece
    void ResetCurrentObstacle()
    {
        currentObstacle = null;
    }
}