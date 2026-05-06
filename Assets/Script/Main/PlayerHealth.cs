using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public DeathUIManager deathManager; // 🔥 ADD THIS

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Debug.Log("PLAYER DEAD");

            if (deathManager != null)
            {
                deathManager.ShowDeathScreen(); // 🔥 SHOW UI
            }
        }
    }
}