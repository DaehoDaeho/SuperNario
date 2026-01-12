using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int points = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == false)
        {
            return;
        }

        if(ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(points);
        }

        Destroy(gameObject);
    }
}
