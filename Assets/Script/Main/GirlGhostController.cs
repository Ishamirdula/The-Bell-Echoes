using UnityEngine;
using System.Collections;

public class GirlGhostController : MonoBehaviour
{
    public GameObject ghost;
    public Transform spawnPoint;
    public Transform player;

    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject trigger3;
    public GameObject trigger4;

    private AudioSource ghostAudio;

    private bool hasSpawned = false;
    private bool hasPlayed = false;

    void Start()
    {
        ghostAudio = ghost.GetComponent<AudioSource>();
    }

    // 🔥 Called by Trigger 1 & 2
    public void SpawnGhost()
    {
        if (hasSpawned) return;

        ghost.transform.position = spawnPoint.position;
        ghost.SetActive(true);

        trigger1.SetActive(false);
        trigger2.SetActive(false);

        hasSpawned = true;
    }

    // 🔥 Called by Trigger 3 & 4
    public void PlayLaughAndDisappear()
    {
        if (hasPlayed) return;

        hasPlayed = true;
        StartCoroutine(LaughThenDisappear());
    }

    // IEnumerator LaughThenDisappear()
    // {
    //     ghostAudio.Play();

    //     yield return new WaitForSeconds(ghostAudio.clip.length);

    //     ghost.SetActive(false);
    // }

    IEnumerator LaughThenDisappear()
    {
        // 👁️ LOOK AT PLAYER FIRST
        Vector3 direction = player.position - ghost.transform.position;
        direction.y = 0; // keep only horizontal rotation

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            ghost.transform.rotation = lookRotation;
        }

        // small delay (makes it creepy 😨)
        yield return new WaitForSeconds(0.5f);

        // 😨 PLAY LAUGH
        ghostAudio.Play();

        yield return new WaitForSeconds(ghostAudio.clip.length);

        // 👻 DISAPPEAR
        ghost.SetActive(false);

        // 🚫 disable triggers AFTER
        trigger3.SetActive(false);
        trigger4.SetActive(false);
    }
}