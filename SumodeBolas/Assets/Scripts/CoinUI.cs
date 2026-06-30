using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void OnEnable()
    {
        PlayerOM.OnCoinCollected += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerOM.OnCoinCollected -= UpdateCoins;
    }

    void UpdateCoins(int amount)
    {
        coinText.text = "Moedas: " + amount;
    }
}