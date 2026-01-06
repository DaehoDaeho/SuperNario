using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // 인스펙터 창에는 노출이 되지만, 다른 클래스에서는 접근할 수 없도록....
    [SerializeField] private int maxHealth = 5;

    private int currentHealth = 0;

    public GameObject gameOverUI;

    private bool isDead = false;

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
        Debug.Log("꼴까닥!");
        isDead = true;

        if(gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        if(isDead == true)
        {
            return;
        }

        if(currentHealth == maxHealth)
        {
            return;
        }

        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
