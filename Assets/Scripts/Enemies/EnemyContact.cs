using UnityEngine;

public class EnemyContact : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1f;
    private float damageTimer;

    void Update()
    {
        if (damageTimer > 0)
            damageTimer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            DealDamage(other.gameObject);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            DealDamage(other.gameObject);
    }

    void DealDamage(GameObject player)
    {
        if (damageTimer <= 0)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
                playerHealth.TakeDamage(damage);

            damageTimer = damageCooldown;
        }
    }
}