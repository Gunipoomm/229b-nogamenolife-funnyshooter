using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public Transform playerTransform; // ตัวละครผู้เล่น
    public Vector3 offset = new Vector3(0, 1.5f, 0); // ระยะลอยเหนือหัว
    public GameObject[] heartIcons; // Array ของหัวใจ

    void Update()
    {
        // ติดตามตำแหน่งผู้เล่นตลอดเวลา
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
        }
    }

    // ฟังก์ชันสำหรับอัปเดตจำนวนหัวใจตาม HP ที่เหลือ
    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].SetActive(i < currentHealth); // แสดงเฉพาะหัวใจที่เหลือ
        }
    }
}
