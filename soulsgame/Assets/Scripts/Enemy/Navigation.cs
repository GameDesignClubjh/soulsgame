using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    bool playerFound = false;

    [SerializeField]
    float fov = 0.0f;   //idk if I'm using this yet
    [SerializeField]
    Transform target;  //the target
    [SerializeField]
    string wallTag; //tag of the obstacles
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SendRay();
       
    }

    void SendRay() //sends a raycast to the target to see if there is anything in thhe way
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position); //sends a ray to the target
        if (hit.collider.tag == target.tag)
        {
            playerFound = true;
            InvokeRepeating("SendRay", 0.0f, 0.3f);
        }
    }



    private void findPath() //finds the path to the target
    {
        Queue<Vector2> checkpoints = new Queue<Vector2>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position);  //send a ray to the target
        if(hit.collider.tag == wallTag) 
        {

           
            checkpoints.Enqueue(hit.transform.position);
            RaycastHit2D sweep = Physics2D.Raycast(transform.position, hit.transform.position);  //sends a ray to the collision
            // make the ray sweep left and right until it sees open space
        }
    }
    
}
