using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  
   
    [SerializeField] private KeyCode upKey;     
    [SerializeField] private KeyCode downKey;   

    private Rigidbody2D rb;
    public float sizeIncrease = 1.5f;
    public float speedIncrease = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {   
        if (Input.GetKey(upKey))
        {
            rb.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
        else if (Input.GetKey(downKey))
        {
            rb.AddForce(Vector3.down * speed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    public void IncreaseSize()
    {
        transform.localScale *= sizeIncrease;
    }

    public void IncreaseSpeed()
    {
        speed *= speedIncrease;
    }
}
