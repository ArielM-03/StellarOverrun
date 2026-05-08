using UnityEngine;

public class ShotgunShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1.5f;
    public float projectileSpeed = 8f;
    public float detectionRange = 10f;
    public float spreadAngle = 25f;

    public AudioSource gunAudio;

    private float fireTimer;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            ShootSpread();
        }
    }

    void ShootSpread()
    {
        GameObject nearestEnemy = FindNearestEnemy();
        if (nearestEnemy == null) return;

        Vector2 baseDirection = (nearestEnemy.transform.position - transform.position).normalized;

        float[] angles = { -spreadAngle, 0f, spreadAngle };

        foreach (float angle in angles)
        {
            Vector2 spreadDirection = RotateVector(baseDirection, angle);
            FireProjectile(spreadDirection);
        }

        if (gunAudio != null)
            gunAudio.PlayOneShot(gunAudio.clip, 0.3f);
    }

    void FireProjectile(Vector2 direction)
    {
        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * projectileSpeed;
        Destroy(bullet, 3f);
    }

    Vector2 RotateVector(Vector2 vector, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(rad);
        float sin = Mathf.Sin(rad);
        return new Vector2(
            vector.x * cos - vector.y * sin,
            vector.x * sin + vector.y * cos
        );
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