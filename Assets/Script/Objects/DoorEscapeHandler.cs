using UnityEngine;

public class DoorEscapeHandler : MonoBehaviour
{
    public SingleDoor door; // reference to your door script
    public GameObject youEscapedCanvas;

    private bool shown = false;

    void Update()
    {
        // check if door is open and not already shown
        if (door.open && door.isExitDoor && !shown)
        {
            shown = true;

            if (youEscapedCanvas != null)
            {
                youEscapedCanvas.SetActive(true);

                // unlock cursor
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                Time.timeScale = 0f; // pause game
            }
        }
    }
}