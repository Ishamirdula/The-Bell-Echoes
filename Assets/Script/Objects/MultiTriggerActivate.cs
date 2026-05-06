using UnityEngine;

public class MultiTriggerActivate : MonoBehaviour
{
    public GameObject objectToEnable;
    public GameObject[] allTriggers; // assign both triggers here

    private static bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            objectToEnable.SetActive(true);
            activated = true;

            // disable all triggers
            foreach (GameObject t in allTriggers)
            {
                t.SetActive(false);
            }
        }
    }
}