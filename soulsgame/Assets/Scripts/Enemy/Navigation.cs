using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

    bool playerFound = false;

    [SerializeField]
    float fov = 0.0f;
    Transform target;
    float wallAvoidLength;
    TagHandle wall;
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

    void SendRay()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position);
        if (hit.collider.tag == target.tag)
        {
            playerFound = true;
            InvokeRepeating("SendRay", 0.0f, 0.3f);
        }
    }



    private void findPath()
    {
        List<Vector2> firstList = new List<Vector2>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position);
    }
    
}
