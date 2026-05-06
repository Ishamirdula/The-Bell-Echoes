using UnityEngine;
using System.Collections;

public class BellSoundLoop : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bellSound;

    public float interval = 180f; // 3 minutes (180 seconds)

    void Start()
    {
        StartCoroutine(PlayBellLoop());
    }

    IEnumerator PlayBellLoop()
    {
        while (true)
        {
            // 🔔 play sound
            if (audioSource != null && bellSound != null)
            {
                audioSource.PlayOneShot(bellSound);
            }

            // ⏱️ wait for 3 minutes
            yield return new WaitForSeconds(interval);
        }
    }
}