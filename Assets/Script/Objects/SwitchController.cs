using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public GameObject switchOn;
    public GameObject switchOff;

    public GameObject hallwayLightOn;
    public GameObject hallwayLightOff;

    private bool lightsAreOn = true;

    public void ToggleSwitch()
    {
        lightsAreOn = !lightsAreOn;

        // Toggle switch visuals
        switchOn.SetActive(lightsAreOn);
        switchOff.SetActive(!lightsAreOn);

        // Toggle hallway light parents
        hallwayLightOn.SetActive(lightsAreOn);
        hallwayLightOff.SetActive(!lightsAreOn);
    }
}