using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    private CoinCounter coinCounter;

    void Start()
    {
        coinCounter = FindObjectOfType<CoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (coinCounter != null)
            {
                coinCounter.UpdateCoinCount();
            }
            Destroy(gameObject);
        }
    }
}
