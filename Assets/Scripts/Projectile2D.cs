using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    [SerializeField] Transform shootPoint;
    [SerializeField] GameObject target; // crosshair
    [SerializeField] Rigidbody2D bulletPrefab;

    void Update()
    {
        UpdateCrosshair();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void UpdateCrosshair()
    {
        // คำนวณตำแหน่งเมาส์ในโลก
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // ขยับ Crosshair ไปที่ตำแหน่งเมาส์
        if (target != null)
        {
            target.transform.position = mouseWorldPos;
        }
    }

    void Shoot()
    {
        // สร้างวิถีกระสุนไปยังตำแหน่ง crosshair
        Vector2 targetPos = target.transform.position;
        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, targetPos, 1f); // 1 วินาที

        // ยิงกระสุน
        Rigidbody2D bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.linearVelocity = projectileVelocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        return new Vector2(velocityX, velocityY);
    }
}
