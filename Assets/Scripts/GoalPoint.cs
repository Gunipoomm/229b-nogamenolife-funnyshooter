using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] string nextSceneName = "EndCredit";
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] float delayBeforeLoad = 2f;

    private void Start()
    {
        if (winText != null)
        {
            winText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowWinAndLoad());
        }
    }

    private System.Collections.IEnumerator ShowWinAndLoad()
    {
        if (winText != null)
        {
            winText.enabled = true;
            winText.text = "You Win!";
        }

        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(nextSceneName);
    }
}
