using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;
    public float moveSpeed = 5.0f;

    private float xInput = 0;
    private float yInput = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
   

    private void FixedUpdate()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {


            rb.linearVelocity = new Vector2(xInput * moveSpeed, yInput * moveSpeed);
        }
    }
}
