using UnityEngine;
public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public EnemyHealthUI healthUI;

    public float damageCooldown = 1f; // หน่วงเวลาหลังชนก่อนจะทำดาเมจได้อีก
    private float lastDamageTime;

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown;

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time - lastDamageTime >= damageCooldown)
            {
                PlayerHealth player = collision.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.TakeDamage(1);
                    lastDamageTime = Time.time; // อัปเดตเวลาที่โดนครั้งล่าสุด
                }
            }
        }
    }
}
