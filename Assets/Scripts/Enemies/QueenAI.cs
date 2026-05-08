using UnityEngine;

public class QueenAI : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1.5f;

    [Header("Pulse Settings")]
    public float pulseInterval = 5f;
    public float pulseRadius = 10f;
    public float speedBoostAmount = 2f;
    public float boostDuration = 3f;

    [Header("Visual Flash")]
    public Color normalColor = Color.white;
    public Color pulseColor = new Color(1f, 0.6f, 0f, 1f);
    public float flashDuration = 0.5f;

    private Transform player;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float pulseTimer;
    private float flashTimer;
    private bool isFlashing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        pulseTimer = pulseInterval;
    }

    void Update()
    {
        HandlePulseTimer();
        HandleFlash();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        if (direction.x > 0)
            spriteRenderer.flipX = true;
        else if (direction.x < 0)
            spriteRenderer.flipX = false;

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }

    void HandlePulseTimer()
    {
        pulseTimer -= Time.deltaTime;

        if (pulseTimer <= 0f)
        {
            pulseTimer = pulseInterval;
            EmitPulse();
        }
    }

    void EmitPulse()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (enemy == gameObject) continue;

            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance <= pulseRadius)
            {
                EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
                if (enemyAI != null)
                    StartCoroutine(BoostEnemy(enemyAI));
            }
        }

        TriggerFlash();
    }

    System.Collections.IEnumerator BoostEnemy(EnemyAI enemyAI)
    {
        float originalSpeed = enemyAI.moveSpeed;
        enemyAI.moveSpeed += speedBoostAmount;
        yield return new WaitForSeconds(boostDuration);
        enemyAI.moveSpeed = originalSpeed;
    }

    void TriggerFlash()
    {
        isFlashing = true;
        flashTimer = flashDuration;
        spriteRenderer.color = pulseColor;
    }

    void HandleFlash()
    {
        if (!isFlashing) return;

        flashTimer -= Time.deltaTime;
        if (flashTimer <= 0f)
        {
            isFlashing = false;
            spriteRenderer.color = normalColor;
        }
    }
}