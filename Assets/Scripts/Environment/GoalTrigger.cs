using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == false)
        {
            return;
        }

        if(GameStateManager.instance != null)
        {
            GameStateManager.instance.SetStageClear();
        }
    }
}
