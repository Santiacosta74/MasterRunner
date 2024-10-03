using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image[] heartImages; // Array de im�genes de corazones
    [SerializeField] private Sprite fullHeart; // Imagen del coraz�n lleno
    [SerializeField] private Sprite emptyHeart; // Imagen del coraz�n vac�o
    [SerializeField] private Sprite halfHeart;  // Imagen del coraz�n medio

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth == null)
        {
            Debug.LogError("No se encontr� PlayerHealth en la escena.");
            return;
        }

        UpdateHealthUI();
    }

    void Update()
    {
        // Actualizar la UI solo si la salud del jugador cambia
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (playerHealth == null)
            return;

        float currentHealth = playerHealth.GetCurrentHealth(); // Obtener salud actual como float
        int fullHearts = Mathf.FloorToInt(currentHealth); // Convertir a int usando la parte entera
        int halfHeartIndex = (currentHealth % 1 >= 0.5f) ? fullHearts : fullHearts - 1;

        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < fullHearts)
            {
                heartImages[i].sprite = fullHeart;
            }
            else if (i == halfHeartIndex)
            {
                heartImages[i].sprite = halfHeart;
            }
            else
            {
                heartImages[i].sprite = emptyHeart;
            }
        }
    }
}
