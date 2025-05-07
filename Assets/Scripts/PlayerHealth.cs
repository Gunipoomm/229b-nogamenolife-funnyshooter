using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public PlayerHealthUI healthUI;

    public TMP_Text gameOverText; 
    public float deathDelay = 2f; 

    void Start()
    {
        currentHealth = maxHealth;
        if (healthUI != null)
        {
            healthUI.UpdateHearts(currentHealth);
        }

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); 
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current HP: " + currentHealth);

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
        Debug.Log("Player Died!");

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); 
        }

        StartCoroutine(RestartSceneAfterDelay());
    }

    IEnumerator RestartSceneAfterDelay()
    {
        yield return new WaitForSeconds(deathDelay);
        SceneManager.LoadScene("Menu"); 
    }
}
