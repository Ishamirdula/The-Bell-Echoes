using System.Collections; 
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public Transform defaultSpawn;
    public Transform puzzleSpawn;

    IEnumerator Start()
    {
        yield return null;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player not found!");
            yield break;
        }

        if (GameData.puzzleSolved)
        {
            player.transform.position = puzzleSpawn.position;
            GameData.puzzleSolved = false; // reset
            this.enabled = false; // 🔥 DISABLE SCRIPT AFTER USE
        }
        else
        {
            player.transform.position = defaultSpawn.position;
        }
    }
}