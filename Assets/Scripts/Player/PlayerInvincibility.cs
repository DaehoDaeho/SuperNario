using System.Collections;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDuration = 1.0f;

    [SerializeField]
    private float blinkInterval = 0.1f;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private bool isInvincible = false;

    private Coroutine invincibleCoroutine = null;

    public bool IsInvincible()
    {
        return isInvincible;
    }

    public void StartInvincibility()
    {
        if(isInvincible == true)
        {
            return;
        }

        if(spriteRenderer == null)
        {
            return;
        }

        if(invincibleCoroutine != null)
        {
            StopCoroutine(InvincibilityCoroutine());
            invincibleCoroutine = null;
        }

        invincibleCoroutine = StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        float elapsed = 0.0f;

        while(elapsed < invincibilityDuration)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);

            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);

            elapsed += blinkInterval * 2.0f;
        }

        spriteRenderer.enabled = true;

        isInvincible = false;

        invincibleCoroutine = null;
    }
}
