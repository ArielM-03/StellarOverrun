using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f;
    public float projectileSpeed = 8f;
    public float detectionRange = 10f;

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            ShootAtNearestEnemy();
        }
    }

    void ShootAtNearestEnemy()
    {
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy == null) return;

        Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * projectileSpeed;

        Destroy(bullet, 3f);
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float shortestDistance = detectionRange;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }
}