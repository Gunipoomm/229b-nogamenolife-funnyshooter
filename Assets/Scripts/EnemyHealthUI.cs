using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Image[] heartIcons; // ต้องเซ็ตหัวใจใน Inspector
    public Vector3 offset = new Vector3(0, 1.5f, 0); // ตำแหน่งลอยบนหัว

    private Transform enemyTransform;

    private void Start()
    {
        enemyTransform = transform.parent; // สมมติ Canvas อยู่ใต้ Enemy
    }

    private void Update()
    {
        if (enemyTransform != null)
            transform.position = enemyTransform.position + offset;
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = i < currentHealth;
        }
    }
}
