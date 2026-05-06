using UnityEngine;

public class GirlGhostTrigger : MonoBehaviour
{
    public GirlGhostController ghostController;

    public enum TriggerType
    {
        Spawn,
        Laugh
    }

    public TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (triggerType == TriggerType.Spawn)
            {
                ghostController.SpawnGhost();
            }
            else if (triggerType == TriggerType.Laugh)
            {
                ghostController.PlayLaughAndDisappear();
            }

            gameObject.SetActive(false); // disable this trigger
        }
    }
}