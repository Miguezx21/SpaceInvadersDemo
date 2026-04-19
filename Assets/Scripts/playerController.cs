using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveSpeed = 210f; // 🔥 MUCHO más rápido
    private float hInput;

    private float xLimit;

    void Start()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;

        // 🔥 Ajuste más cerrado (antes -2)
        xLimit = screenHalfWidth - 20f;
    }

    void Update()
    {
        // Input inmediato
        hInput = Input.GetAxisRaw("Horizontal");

        // Movimiento MÁS directo y rápido
        float newX = transform.position.x + hInput * moveSpeed * Time.deltaTime;

        // 🔥 Clamp antes de asignar (más preciso)
        newX = Mathf.Clamp(newX, -xLimit, xLimit);

        transform.position = new Vector2(newX, transform.position.y);
    }
}