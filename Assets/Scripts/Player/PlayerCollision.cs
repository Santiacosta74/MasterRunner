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
            // Actualiza la UI de salud si el método está en PlayerHealth
            playerHealth.UpdateHealthUI(); // Asegúrate de que este método exista en PlayerHealth
        }
    }
}
