using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public int maxJumps = 2; // จำนวนกระโดดสูงสุด
    private int jumpCount;

    private Rigidbody2D rb2d;
    private PlayerHealth playerHealth;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>(); // อ้างอิง script Health
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0); // reset y เพื่อให้โดดเสมอกัน
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            jumpCount--;
            Debug.Log("Jump, remaining: " + jumpCount);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // รีเซ็ตจำนวนกระโดดเมื่อแตะพื้น
        if (other.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumps;
        }

        // ถ้าโดนศัตรูชน
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
