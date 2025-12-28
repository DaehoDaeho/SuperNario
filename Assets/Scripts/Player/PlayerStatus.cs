using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string playerName = "me";
    public int maxHp = 50;
    public int hp = 10;
    public int attack = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("플레이어가 준비되었습니다. " + playerName);
        Debug.Log("HP: " + hp + "/" + maxHp + ", 공격력: " + attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 플레이어가 대미지를 받아 hp 감소 처리.
    /// </summary>
    /// <param name="damage">대미지 양</param>
    public void TakeDamage(int damage)
    {
        hp -= damage;

        if(hp < 0)
        {
            hp = 0;
        }

        Debug.Log(playerName + "이(가) " + damage + "의 대미지를 받았습니다. HP: " + hp);
    }

    public void Heal(int amount)
    {
        hp += amount;

        if(hp > maxHp)
        {
            hp = maxHp;
        }

        Debug.Log(playerName + "이(가) " + amount + "만큼 체력을 회복했습니다. HP: " + hp);
    }

    public bool IsDead()
    {
        if(hp <= 0)
        {
            return true;
        }

        return false;
    }
}
