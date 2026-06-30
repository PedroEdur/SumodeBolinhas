using UnityEngine;

public class PlayerCoinCollector : MonoBehaviour
{
    private int coins = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;

            // Notifica a interface
            PlayerOM.CollectCoin(coins);

            // Destrói moeda
            Destroy(other.gameObject);
        }
    }
}