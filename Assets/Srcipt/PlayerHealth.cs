using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerRespawn respawn;
    private bool isDead = false;

    void Start()
    {
        respawn = GetComponent<PlayerRespawn>();
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Player Dead!");

        // เรียก Respawn
        respawn.Respawn();

        // รีเซ็ตสถานะ
        isDead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap") || collision.CompareTag("Enemy"))
        {
            Die();
        }
    }
}