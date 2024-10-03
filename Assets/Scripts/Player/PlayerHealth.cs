using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Asegúrate de que la UI se actualice al inicio
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI(); // Actualiza la UI cuando se recibe daño
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Hacer público para que otras clases puedan llamarlo si es necesario
    public void UpdateHealthUI()
    {
        // Aquí puedes actualizar la UI si prefieres hacerlo en esta clase
        // Alternativamente, puedes manejarlo en PlayerHealthUI como se muestra arriba
    }

    private void Die()
    {
        // Maneja la muerte del jugador aquí
    }
}
