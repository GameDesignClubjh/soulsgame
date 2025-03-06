using UnityEngine;

public class DumpterDiving : MonoBehaviour
{

    public GameObject Raccoon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRaccoon", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin,
                Camera.main.ScreenPointToRay(Input.mousePosition).direction);
            if (hit)
            {
               
                if (hit.collider.tag == "Raccoon")
                {
                    Debug.Log("grah");
                    
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag == "Trash")
                {
                    Transform trash = hit.collider.gameObject.transform;
                    trash.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.0f));
                }
            }
        }
    }

    void SpawnRaccoon()
    {
        float randX = Random.Range(-3.0f, 3.0f);
        float randY = Random.Range(-3.0f, 3.0f);
        Vector2 cords = new Vector2(randX, randY);  

        Instantiate(Raccoon, cords, Raccoon.transform.rotation);
    }
}
