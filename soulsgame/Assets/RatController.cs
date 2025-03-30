using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class RatController : MonoBehaviour
{

    public List<GameObject> targets = new List<GameObject>();
    public List<UnityEngine.Transform> checkPoints = new List<UnityEngine.Transform>();
    private GameObject chosenTarget;
    int targetNum = 0;
    int counter = 0;
    public float speed = 10.0f;
    private UnityEngine.Transform targetPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetNum = UnityEngine.Random.Range(0, 2);
      
        Debug.Log(targetNum);

        chosenTarget = targets[1];
        Debug.Log(chosenTarget.name);

        Debug.Log(targets.Count);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, chosenTarget.transform.position);
        Debug.DrawRay(transform.position, chosenTarget.transform.position, Color.red);
        Debug.Log(chosenTarget.transform.position);
        // If it hits something...
        if (hit)
        {

            Debug.Log(hit);
            if (hit.collider.tag == chosenTarget.tag)
            {
                transform.position = Vector2.MoveTowards(transform.position, chosenTarget.transform.position, speed * Time.deltaTime);
                Debug.Log("hi");
            }


            else if (hit.collider.IsTouchingLayers(3))
            {
                float targetDistance = Vector2.Distance(transform.position, chosenTarget.transform.position);//get distance from chosenTarget and rat
                float smallDistance = 0;
                for (int i = 0; i < checkPoints.Count - 1; i++)
                {
                    smallDistance = Vector2.Distance(transform.position, checkPoints[i].position);
                    for (int j = 0; j < checkPoints.Count - i; j++)
                    {
                        float tempDistance = Vector2.Distance(transform.position, checkPoints[j].position);

                        if (smallDistance > tempDistance)
                        {
                            smallDistance = tempDistance;
                            targetPoint = checkPoints[j];
                        }
                    }
                }

                if (targetDistance < smallDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, chosenTarget.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPoint.transform.position, speed * Time.deltaTime);
                }

            }



        }


    }
}


    

