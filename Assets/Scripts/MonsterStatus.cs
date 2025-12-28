using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    public string monsterName = "enemy";
    public int maxHp = 80;
    public int hp = 80;
    public int attack = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("몬스터 준비되었습니다. " + monsterName);
        Debug.Log("HP: " + hp + "/" + maxHp + ", 공격력: " + attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            hp = 0;
        }

        Debug.Log(monsterName + "이(가) " + damage + "의 대미지를 받았습니다. HP: " + hp);
    }

    public void Heal(int amount)
    {
        hp += amount;

        if (hp > maxHp)
        {
            hp = maxHp;
        }

        Debug.Log(monsterName + "이(가) " + amount + "만큼 체력을 회복했습니다. HP: " + hp);
    }

    public bool IsDead()
    {
        if (hp <= 0)
        {
            return true;
        }

        return false;
    }
}
