using UnityEngine;

public class BellInteraction : MonoBehaviour
{
    public Transform player; // 🔥 player position
    public float interactDistance = 3f;

    public GameObject bell_1;
    public GameObject bell_2;

    public AudioSource audioSource;
    public AudioClip bellBreakSound;
    public AudioClip ghostScreamSound;

    private bool isBroken = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isBroken)
        {
            float distance = Vector3.Distance(player.position, bell_1.transform.position);

            if (distance <= interactDistance)
            {
                BreakBell();
            }
            else
            {
                Debug.Log("Go closer to the bell");
            }
        }
    }

    void BreakBell()
    {
        isBroken = true;

        bell_1.SetActive(false);
        bell_2.SetActive(true);

        // 🔊 Bell break sound
        if (audioSource != null && bellBreakSound != null)
        {
            audioSource.PlayOneShot(bellBreakSound);
        }

        // 👻 Ghost scream after delay
        Invoke("PlayGhostSound", 1.5f);
    }

    void PlayGhostSound()
    {
        if (audioSource != null && ghostScreamSound != null)
        {
            audioSource.PlayOneShot(ghostScreamSound);
        }
    }
}