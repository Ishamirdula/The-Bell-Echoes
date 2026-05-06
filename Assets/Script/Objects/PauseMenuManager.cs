using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson; // IMPORTANT

public class PauseMenuManager : MonoBehaviour
{
    public GameObject panel1; // Pause Menu
    public GameObject panel2; // Sub Menu

    public FirstPersonController playerController; // 🔥 drag player here

    private bool isPaused = false;

    // 🔹 MENU BUTTON → switch panels
    public void OpenMenuPanel()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    // 🔹 PLAY → continue game
    public void ContinueGame()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        // 🔥 LOCK MOUSE BACK
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // 🔥 ENABLE PLAYER MOVEMENT
        if (playerController != null)
            playerController.enabled = true;
    }

    // 🔹 REPLAY → restart
    public void ReplayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 🔹 MAIN MENU
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroMainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                // 🔥 PAUSE GAME
                panel1.SetActive(true);
                panel2.SetActive(false);

                Time.timeScale = 0f;
                isPaused = true;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // 🔥 DISABLE PLAYER
                if (playerController != null)
                    playerController.enabled = false;
            }
            else
            {
                // 🔥 RESUME GAME
                ContinueGame();
            }
        }
    }
}