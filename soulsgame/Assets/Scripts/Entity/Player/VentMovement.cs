using UnityEngine;

public class VentMovement : MonoBehaviour

{

   
    public Transform player;
    public float moveSpeed = 7f;
    public Transform[] columns;
    int i = 1;
    bool isStopped;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            Debug.Log("hello");
            if (Input.GetAxisRaw("Horizontal") > 0 && i < columns.Length - 1)
            {
                player.position = columns[i + 1].position;
                i++;
            }
             else if (Input.GetAxisRaw("Horizontal") < 0 && i > 0)
            {
                player.position = columns[i - 1].position;
                i--;
            }
        }

        //add cooldown for moving
        }
    private void FixedUpdate()
    {
        transform.position += transform.up * moveSpeed;
        
        

    }
}
