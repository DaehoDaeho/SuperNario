using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int healthAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") == false)
        {
            return;
        }

        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.Heal(healthAmount);
        }

        Destroy(gameObject);
    }
}
