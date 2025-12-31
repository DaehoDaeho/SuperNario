using UnityEngine;

/// <summary>
/// 적 캐릭터의 체력을 관리.
/// 최대 체력과 현재 체력을 보관.
/// 외부에서 공격을 받으면 대미지 값을 받아 체력을 감소.
/// 체력이 0 이하가 되면 사망 처리.
/// </summary>
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;

    public int currentHealth = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("꼴까닥!");
        Destroy(gameObject);
    }
}
