using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;

    public int currentHealth = 0;

    public GameObject gameOverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("²Ã±î´Ú!");

        if(gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
