using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyPickUpObject : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject ThisTrigger;
    public GameObject Object0nGround;
    public GameObject ObjectOnHand; 
    public SwitchLights playerSwitch;
    public GameObject NextInstruction;
    public bool Action = false;

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        ThisTrigger.SetActive(true);
        Object0nGround.SetActive(true);
        ObjectOnHand.SetActive(false);
        NextInstruction.SetActive(false);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Instruction.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
            Instruction.SetActive(false);
            Action = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                Object0nGround.SetActive(false);
                ObjectOnHand.SetActive(true);
                ThisTrigger.SetActive(false);
                NextInstruction.SetActive(true);
                Invoke("HideInstruction", 4f);

                playerSwitch.hasKey = true;

                Action = false; //
            }
        }
    }

    void HideInstruction()
    {
        NextInstruction.SetActive(false);
    }
}
