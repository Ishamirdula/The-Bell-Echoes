using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlInfo;

    // ▶️ PLAY BUTTON
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGameScene"); // scene name
    }

    // 🎮 CONTROL BUTTON
    public void ShowControls()
    {
        mainMenu.SetActive(false);
        controlInfo.SetActive(true);
    }

    // 🔙 BACK BUTTON (optional for Control screen)
    public void BackToMenu()
    {
        controlInfo.SetActive(false);
        mainMenu.SetActive(true);
    }

    // ❌ QUIT BUTTON
    public void QuitGame()
    {
        Debug.Log("Game Quit"); // works in editor
        Application.Quit();    // works in build
    }
}