using UnityEngine;
using System.Collections.Generic;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private int initialSize = 30;

    [SerializeField]
    private bool canExpand = true;

    [SerializeField]
    private int expandCount = 10;

    private List<Projectile> allProjectiles = new List<Projectile>();

    private void Awake()
    {
        Prewarm();
    }

    /// <summary>
    /// 게임 시작 시 총알을 미리 생성하는 함수.
    /// </summary>
    void Prewarm()
    {
        for(int i=0; i<initialSize; ++i)
        {
            CreateProjectile();
        }
    }

    Projectile CreateProjectile()
    {
        GameObject go = Instantiate(projectilePrefab.gameObject, transform.position, Quaternion.identity);

        if(go == null)
        {
            return null;
        }

        Projectile projectile = go.GetComponent<Projectile>();
        if (projectile == null)
        {
            Destroy(go);
            return null;
        }

        // 일단 총알의 부모를 Pool 오브젝트로 설정해둔다.
        go.transform.SetParent(transform);

        // 투사체 스크립트에 소유자 정보를 넘겨준다.
        // 조금 있다가 합시다.
        projectile.SetPool(this);

        projectile.gameObject.SetActive(false);
        allProjectiles.Add(projectile);

        return projectile;
    }

    public Projectile Get()
    {
        Projectile p = null;
        if(allProjectiles.Count > 0)    // 리스트에 사용가능한 총알이 있을 경우.
        {
            p = allProjectiles[0];  // 리스트의 첫번째 총알을 가져온다.
            p.gameObject.SetActive(true);   // 가져온 총알을 활성화.
            allProjectiles.RemoveAt(0); // 가져온 총알을 리스트에서 삭제.
        }
        else
        {
            // 리스트에 남은 총알이 없고 추가생성을 할 수 있다면.
            if (canExpand == true)
            {
                for (int i = 0; i < expandCount; ++i)
                {
                    CreateProjectile();
                }

                p = allProjectiles[0];
                p.gameObject.SetActive(true);
                allProjectiles.RemoveAt(0);
            }
        }

        return p;
    }

    public void Return(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        allProjectiles.Add(projectile);
    }
}
