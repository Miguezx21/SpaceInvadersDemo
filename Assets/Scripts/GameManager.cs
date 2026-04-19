using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar
using TMPro; // Necesario si usas TextMeshPro

public class GameManager : MonoBehaviour
{
    public GameObject winMessage; // Arrastra aquí el objeto "YouWin"
    public GameObject loseMessage; // Arrastra aquí el objeto "GAME OVER"
    private bool isGameOver = false;

    void Start()
    {
        // Al empezar, nos aseguramos de que los mensajes estén apagados
        if (winMessage != null) winMessage.SetActive(false);
        if (loseMessage != null) loseMessage.SetActive(false);
    }

    void Update()
    {
        // 1. Lógica para Ganar: Buscar si quedan aliens en la escena
        GameObject[] aliens = GameObject.FindGameObjectsWithTag("Alien");

        if (aliens.Length == 0 && !isGameOver)
        {
            WinGame();
        }

        // 2. Lógica para Reiniciar
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            // Carga la escena actual de nuevo
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void WinGame()
    {
        isGameOver = true;
        if (winMessage != null) winMessage.SetActive(true);
    }

    public void LoseGame() // Esta la llamaremos desde el script de vidas
    {
        isGameOver = true;
        if (loseMessage != null) loseMessage.SetActive(true);
    }
}