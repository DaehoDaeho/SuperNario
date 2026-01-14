using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    [SerializeField]
    private float knockbackForceX = 8.0f;

    [SerializeField]
    private float knockbackForceY = 6.0f;

    [SerializeField]
    private float knockbackDuration = 0.25f;

    private float knockbackTimer = 0.0f;
    private bool isKnockbackActive = false;

    private Vector2 knockbackVelocity = Vector2.zero;   // (0.0f, 0.0f)

    // Update is called once per frame
    void Update()
    {
        if(isKnockbackActive == true)
        {
            knockbackTimer -= Time.deltaTime;

            if(knockbackTimer <= 0.0f)
            {
                isKnockbackActive = false;
                knockbackTimer = 0.0f;

                knockbackVelocity = Vector2.zero;
            }
        }
    }

    public bool IsKnockbackActive()
    {
        return isKnockbackActive;
    }

    public Vector2 GetKnockbackVelocity()
    {
        return knockbackVelocity;
    }

    public void ApplyKnockback(Vector2 direction)
    {
        isKnockbackActive = true;

        knockbackTimer = knockbackDuration;

        float xSign = 1.0f;
        if(direction.x < 0.0f)
        {
            xSign = -1.0f;
        }

        float vx = xSign * knockbackForceX;
        float vy = knockbackForceY;

        knockbackVelocity = new Vector2(vx, vy);
    }
}
