using UnityEngine;

public class TurnBasedBattle : MonoBehaviour
{
    public PlayerStatus player;
    public MonsterStatus monster;

    public int turnCount = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SimulateBattle();
    }

    void SimulateBattle()
    {
        for(int i=1; i<=turnCount; ++i)
        {
            Debug.Log("=== 턴 " + i + " 시작!!");

            Debug.Log("플레이어의 공격!");
            monster.TakeDamage(player.attack);

            if(monster.IsDead() == true)
            {
                Debug.Log("몬스터를 처치했습니다~~~ 플레이어의 승리~~~");
                break;
            }

            Debug.Log("몬스터의 공격!");
            player.TakeDamage(monster.attack);

            if(player.IsDead() == true)
            {
                Debug.Log("플레이어를 처치했습니다~~~ 몬스터의 승리~~~");
                break;
            }

            Debug.Log("=== 턴 " + i + " 종료!!!");
        }

        Debug.Log("전투가 끝났습니다!!!");
    }
}

