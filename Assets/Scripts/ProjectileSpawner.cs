using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject enemyProjectile;
    public Transform firePoint;
    public float fireRate = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            GameObject bullet = Instantiate(
                enemyProjectile,
                firePoint.position,
                Quaternion.Euler(0, 0, -90)
            );

            bullet.transform.parent = null; // 🔥 clave

            timer = 0f;
        }
    }
}