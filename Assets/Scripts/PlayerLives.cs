using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración de Vidas")]
    public int lives = 3;
    public Image[] livesUI; // Arrastra tus iconos de corazones aquí
    public GameObject explosionPrefab;

    private void Start()
    {
        UpdateLivesUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta colisión con Alien o Proyectil Enemigo
        if (other.CompareTag("Alien") || other.CompareTag("EnemyProjectile"))
        {
            Debug.Log("¡Daño recibido!");

            // Efectos visuales
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            // Destruye lo que nos golpeó
            Destroy(other.gameObject);

            // Restar vida
            LoseLife();
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        Debug.Log("Vidas restantes: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesUI()
    {
        if (livesUI == null) return;

        for (int i = 0; i < livesUI.Length; i++)
        {
            if (livesUI[i] != null)
            {
                // Habilita la imagen solo si el índice es menor a las vidas actuales
                livesUI[i].enabled = i < lives;
            }
        }
    }

    void GameOver()
    {
        Debug.Log("¡Game Over!");

        // Buscamos al GameManager para mostrar el mensaje de "Perdiste"
        GameManager gm = Object.FindFirstObjectByType<GameManager>();
        if (gm != null)
        {
            gm.LoseGame();
        }

        Destroy(gameObject); // Destruye al jugador
    }
}