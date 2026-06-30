using UnityEngine;
public class Splashscript : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(CarregarMenuPrincipal), 2f);
    }

    void CarregarMenuPrincipal()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.IrParaMenuPrincipal();
        }
    }
}