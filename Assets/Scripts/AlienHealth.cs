using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform explosionPoint;
    private PointManager pointManager;

    //Start is called before the first frame update
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Instantiate(explosionPrefab, explosionPoint.position, Quaternion.identity);
            pointManager.UpdateScore(50);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}