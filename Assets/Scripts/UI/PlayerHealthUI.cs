using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Image imageHealth;
    [SerializeField] private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth == null)
        {
            return;
        }

        // 매 프레임마다 플레이어의 현재 HP와 최대 HP 정보를 가져와서 UI를 갱신하는 코드를 작성.
        //int currentHealth = playerHealth.GetCurrentHealth();
        //int maxHealth = playerHealth.GetMaxHealth();

        //if(currentHealth <= 0)
        //{
        //    imageHealth.fillAmount = 0;
        //    return;
        //}

        //float health = (float)currentHealth / (float)maxHealth;
        //imageHealth.fillAmount = health;

        if (playerHealth.GetCurrentHealth() <= 0)
        {
            imageHealth.fillAmount = 0;
            return;
        }

        imageHealth.fillAmount = (float)playerHealth.GetCurrentHealth() / (float)playerHealth.GetMaxHealth();
    }
}
