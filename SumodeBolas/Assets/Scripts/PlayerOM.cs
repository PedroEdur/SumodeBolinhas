using System;

public static class PlayerOM
{
    // Evento das moedas
    public static Action<int> OnCoinCollected;

    // Método para disparar evento
    public static void CollectCoin(int amount)
    {
        OnCoinCollected?.Invoke(amount);
    }
}