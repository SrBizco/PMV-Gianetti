using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // Velocidad de movimiento del jugador
   
    [SerializeField] private KeyCode upKey;     // Tecla para moverse hacia arriba
    [SerializeField] private KeyCode downKey;   // Tecla para moverse hacia abajo

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {   // Maneja el input del jugador basado en las teclas asignadas
        if (Input.GetKey(upKey))
        {
            rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(downKey))
        {
            rb.AddForce(Vector3.down * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
}
