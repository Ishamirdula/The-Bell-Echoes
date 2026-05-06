using UnityEngine;

public class PuzzleResultHandler : MonoBehaviour
{
    public GameObject destroyTool;

    void Start()
    {
        if (GameData.puzzleSolved)
        {
            destroyTool.SetActive(true);
        }
    }
}