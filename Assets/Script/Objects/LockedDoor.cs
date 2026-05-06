using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public GameObject keyOnHand;     // reference to ObjectOnHand
    public float interactDistance = 3f;
    public bool isLocked = true;

    private Transform player;

    void Start()
    {
        // player = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject p = GameObject.FindGameObjectWithTag("Player");
        
        if (p != null)
        player = p.transform;
        else
        Debug.LogError("Player not found!");
    }

    void Update()
    {
        // Check distance
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (isLocked)
                {
                    if (keyOnHand.activeInHierarchy)
                    {
                        UnlockDoor();
                    }
                    else
                    {
                        Debug.Log("You need a key!");
                    }
                }
            }
        }
    }

    void UnlockDoor()
    {
        isLocked = false;

        // Use your existing door system
        SingleDoor door = GetComponent<SingleDoor>();

        if (door != null)
        {
            door.open = true;          // open door
            door.useKeyOnly = true;    // 🔥 IMPORTANT: keep blocking Mouse0
        }

        Debug.Log("Door Unlocked!");

        keyOnHand.SetActive(false); // consume key
    }
}