using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSceneLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("PuzzleGame"); // exact scene name
        }
    }
}