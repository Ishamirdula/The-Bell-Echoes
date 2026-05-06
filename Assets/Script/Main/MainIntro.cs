using UnityEngine;

public class MainIntro : MonoBehaviour
{
    public GameObject canvas_1;
    public GameObject canvas_2;

    // 🎯 COMMON FUNCTION (Timeline + Skip both use this)
    public void GoToMainMenu()
    {
        canvas_1.SetActive(false);
        canvas_2.SetActive(true);
    }

    // ⏭️ Skip button
    public void SkipIntro()
    {
        GoToMainMenu();
    }
}