using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 50f; // 🔥 ahora sí funciona

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}