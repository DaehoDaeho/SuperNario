using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField]
    private Projectile projectilePrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float fireCooldown = 0.25f;

    [SerializeField]
    private KeyCode fireKey = KeyCode.F;

    private float nextFireTime = 0.0f;

    void Fire()
    {
        if(projectilePrefab == null)
        {
            return;
        }

        if(firePoint == null)
        {
            return;
        }

        GameObject go = Instantiate(projectilePrefab.gameObject, firePoint.position, Quaternion.identity);
        if(go != null)
        {
            Projectile projectile = go.GetComponent<Projectile>();
            if(projectile == null)
            {
                Destroy(go);
                return;
            }

            // 캐릭터의 방향을 알아오기 위해서 scale.x값을 가져온다.
            float scaleX = transform.localScale.x;

            // 기본 방향을 오른쪽으로 설정.
            Vector2 dir = Vector2.right;

            // 캐릭터가 왼쪽을 향하고 있는지 검사.
            if(scaleX < 0.0f)
            {
                dir = Vector2.left;
            }

            // 총알의 방향 설정.
            projectile.SetDirection(dir);
        }
    }

    /// <summary>
    /// 발사 키 입력 처리.
    /// </summary>
    void HandleFireInput()
    {
        if(Input.GetKeyDown(fireKey) == false)
        {
            return;
        }

        if(Time.time < nextFireTime)
        {
            return;
        }

        nextFireTime = Time.time + fireCooldown;

        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFireInput();
    }
}
