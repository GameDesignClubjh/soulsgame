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
        if (Input.GetMouseButton(0))// checks if the player has left-clicked
        {
            //sends an invisible line from the camera to the cursor
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, 
                Camera.main.ScreenPointToRay(Input.mousePosition).direction);
            if (hit) //checks if the line hit something
            {

               
                if (hit.collider.tag == "Raccoon") //checks if it hit a raccoon
                {
                    Debug.Log("grah");
                    
                    Destroy(hit.collider.gameObject); //supposed to destroy raccons, does not do that.
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
