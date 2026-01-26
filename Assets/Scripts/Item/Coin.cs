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

        if(AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioType.GainCoin);
        }

        if(ParticleManager.instance != null)
        {
            ParticleManager.instance.PlayFX(ParticleType.GainCoin, transform.position);
        }

        Destroy(gameObject);
    }
}
