using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().MovePosition(
            GetComponent<Rigidbody2D>().position + direction * moveSpeed * Time.fixedDeltaTime
        );
    }
}