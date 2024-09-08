using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del jugador
    public KeyCode upKey;     // Tecla para moverse hacia arriba
    public KeyCode downKey;   // Tecla para moverse hacia abajo

    private float minY, maxY; // Límites de movimiento del jugador

    void Start()
    {
        // Calcula los límites de movimiento para mantener al jugador dentro de la pantalla
        float halfHeight = transform.localScale.y / 2;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + halfHeight;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - halfHeight;
    }

    void Update()
    {
        float move = 0;

        // Maneja el input del jugador basado en las teclas asignadas
        if (Input.GetKey(upKey))
        {
            move = speed * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            move = -speed * Time.deltaTime;
        }

        // Calcula la nueva posición y la limita a los bordes de la pantalla
        float newY = Mathf.Clamp(transform.position.y + move, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
