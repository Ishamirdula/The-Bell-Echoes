using UnityEngine;
using System.Collections;

public class SingleDoor : MonoBehaviour
{
    public bool open = false;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;
    public bool useKeyOnly = false; // NEW

    public bool isExitDoor = false;

    void Start()
    {
       
    }
    

    public void ChangeDoorState()
    {
        //Block mouse interaction for key-only doors
        if (useKeyOnly)
        {
            return;
        }

        open = !open;
    }
    
    void Update()
    {
        /*
        if(open)     //open == true
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
        */

        float targetY = open ? doorOpenAngle : doorCloseAngle;
        Quaternion targetRotation = Quaternion.Euler(0, targetY, 0);
        
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

    }   
}
