using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{

    public float interactDistance = 5f;
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, interactDistance))
            {
                if(hit.collider.CompareTag("Door"))
                {
                    //hit.collider.transform.parent.GetComponent<SingleDoor>().ChangeDoorState();
                    SingleDoor door = hit.collider.GetComponent<SingleDoor>();

                    if (door != null)
                    {
                        door.ChangeDoorState();
                    }

                }
            }
        }
    }
}
