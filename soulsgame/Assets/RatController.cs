using System;
using System.Collections.Generic;
using UnityEngine;


public class RatController : MonoBehaviour
{
   
   public List<GameObject> targets = new List<GameObject>();
    public List<Transform> checkPoints = new List<Transform>();
    int targetNum = 0;
    int counter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       targetNum = UnityEngine.Random.Range(0, targets.Count -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrackToTarget()
    {
        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targets[targetNum].transform.position);

        // If it hits something...
        if (hit)
        { if (hit.collider.tag == "wall" && counter >= 1)
            {
                checkPoints.Add(hit.collider.transform);
                counter++;
            }
           
        }
    }
}
