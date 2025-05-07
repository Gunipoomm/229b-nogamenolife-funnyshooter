using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public ConstantForce2D trapForce;
    public Vector2 launchForce = new Vector2(10f, 0f); // กำหนดทิศทางพุ่ง

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            trapForce.force = launchForce;
            activated = true;
        }
    }
}
