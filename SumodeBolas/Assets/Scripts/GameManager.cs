using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState estadoAtual;
    internal static object instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        TrocarEstado(GameState.Iniciando);
        CarregarSplash();
    }

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public void TrocarEstado(GameState novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado mudou para: " + estadoAtual);
    }

    public void CarregarSplash()
    {
        SceneManager.LoadScene("Splash");
    }

    public void IrParaMenuPrincipal()
    {
        TrocarEstado(GameState.MenuPrincipal);
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void IniciarJogo()
    {
        TrocarEstado(GameState.Gameplay);

        // Carrega gameplay
        SceneManager.LoadScene("SampleScene");

        // Carrega GUI de forma aditiva
        SceneManager.LoadScene("GUI", LoadSceneMode.Additive);

        Debug.Log("Gameplay + GUI carregados");
    }
}
