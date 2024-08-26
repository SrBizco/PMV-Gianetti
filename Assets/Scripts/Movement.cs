using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.01f;
    public KeyCode KeyUp = KeyCode.W;
    public KeyCode KeyLeft = KeyCode.A;
    public KeyCode KeyDown = KeyCode.S;
    public KeyCode KeyRight = KeyCode.D;
    public KeyCode KeyRotLeft = KeyCode.Q;
    public KeyCode KeyRotRight = KeyCode.E;

    void Update()
    {
        Vector3 pos = transform.position;
        
        
        if (Input.GetKey(KeyUp))
        {
            pos.y += speed;
            Debug.Log("se apreto la tecla Up");
        }
        if (Input.GetKey(KeyLeft))
        {
            pos.x -= speed;
            Debug.Log("se apreto la tecla Left");
        }
        if (Input.GetKey(KeyDown))
        {
            pos.y -= speed;
            Debug.Log("se apreto la tecla Down");
        }
        if (Input.GetKey(KeyRight))
        {
            pos.x += speed;
            Debug.Log("se apreto la tecla Right");
        }
        transform.position = pos;
        
        if (Input.GetKeyDown(KeyRotLeft))
        {
            transform.Rotate(0, 0, -10f);
            Debug.Log("se apreto la tecla RotLeft");
        }
        if (Input.GetKeyDown(KeyRotRight))
        {
            transform.Rotate(0, 0, 10f);
            Debug.Log("se apreto la tecla RotRight");
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);
        }

    }
}