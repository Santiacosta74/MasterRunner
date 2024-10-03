using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private int coinCount = 0;
    private string playerPrefsKey = "CoinCount";

    void Start()
    {
        // Cargar el contador de monedas desde PlayerPrefs al inicio del juego
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            coinCount = PlayerPrefs.GetInt(playerPrefsKey);
        }
        UpdateCoinText();
    }

    public void UpdateCoinCount()
    {
        coinCount++;
        UpdateCoinText();

        // Guardar el contador de monedas en PlayerPrefs
        PlayerPrefs.SetInt(playerPrefsKey, coinCount);
        PlayerPrefs.Save();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
