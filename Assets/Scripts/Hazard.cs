using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damage = 1; // ความเสียหายที่จะทำกับผู้เล่น

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
