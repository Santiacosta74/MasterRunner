using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Aseg�rate de que la UI se actualice al inicio
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI(); // Actualiza la UI cuando se recibe da�o
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Hacer p�blico para que otras clases puedan llamarlo si es necesario
    public void UpdateHealthUI()
    {
        // Aqu� puedes actualizar la UI si prefieres hacerlo en esta clase
        // Alternativamente, puedes manejarlo en PlayerHealthUI como se muestra arriba
    }

    private void Die()
    {
        // Maneja la muerte del jugador aqu�
    }
}
