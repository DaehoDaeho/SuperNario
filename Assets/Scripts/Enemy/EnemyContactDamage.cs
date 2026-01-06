using UnityEngine;

public class EnemyContactDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag == "Player")
        if(collision.gameObject.CompareTag("Player") == true)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if(playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("ÆÜ!!!");
            }
        }
    }
}
