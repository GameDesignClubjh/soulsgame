using UnityEngine;

public class DumpterDiving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
