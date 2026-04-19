using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private float xLimit;

    void Start()
    {
        float screenHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
        xLimit = screenHalfWidth - 1f; // margen
    }

    void Update()
    {
        // mover grupo
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // 🔥 obtener todos los aliens (hijos)
        Transform[] aliens = GetComponentsInChildren<Transform>();

        float maxX = float.MinValue;
        float minX = float.MaxValue;

        foreach (Transform alien in aliens)
        {
            if (alien == transform) continue; // ignorar padre

            float x = alien.position.x;

            if (x > maxX) maxX = x;
            if (x < minX) minX = x;
        }

        // 🔥 detectar bordes reales
        if (maxX > xLimit || minX < -xLimit)
        {
            // bajar grupo
            transform.position += Vector3.down * 3f;

            // invertir dirección
            moveSpeed *= -1;
        }
    }
}