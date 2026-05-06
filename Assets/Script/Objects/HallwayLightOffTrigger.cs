using UnityEngine;

public class HallwayLightOffTrigger : MonoBehaviour
{
    public GameObject hallwayLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hallwayLight.SetActive(false);
        }
    }
}