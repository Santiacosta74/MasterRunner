using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            playerHealth.TakeDamage(1);
            // Actualiza la UI de salud si el m�todo est� en PlayerHealth
            playerHealth.UpdateHealthUI(); // Aseg�rate de que este m�todo exista en PlayerHealth
        }
    }
}
