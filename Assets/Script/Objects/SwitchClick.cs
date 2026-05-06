using UnityEngine;

public class SwitchClick : MonoBehaviour
{
    public SwitchController controller;

    private void OnMouseDown()
    {
        controller.ToggleSwitch();
    }
}