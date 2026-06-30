using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public void Jogar()
    {
        GameManager.Instance.IniciarJogo();
    }

    public void Sair()
    {
        Application.Quit();
    }
}