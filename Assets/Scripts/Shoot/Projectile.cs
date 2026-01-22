using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8.0f;

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float lifeTime = 3.0f;

    private float lifeTimer = 0.0f;
    private Vector2 direction = Vector2.right;

    public void SetDirection(Vector2 dir)
    {
        // 순수한 방향정보만 가지고 있는 벡터는 크기가 1이어야 한다.
        // 그래서 크기가 1이 아닌 벡터를 방향정보로 사용하고자 할 경우
        // 이 벡터의 크기를 1로 만들어 줘야 한다.
        // 그렇게 하지 않을 경우 우리가 의도한 속도보다 더 빠르게 날아갈 수 있다.
        // 벡터의 정규화 - 벡터의 크기를 1로 만들어주는 것.
        // 벡터의 크기가 1인 벡터를 단위 벡터(Unit Vector)라고 한다.
        direction = dir.normalized;
    }

    void Move()
    {
        // 이동량 계산 = 방향 * 속력.
        Vector2 delta = direction * moveSpeed * Time.deltaTime;

        // 현재 위치 저장.
        Vector3 pos = transform.position;

        // 새로 이동할 위치 계산.
        float newX = pos.x + delta.x;
        float newY = pos.y + delta.y;

        // 오브젝트의 위치 갱신 : z 좌표 값은 기존의 값을 그대로 사용.
        transform.position = new Vector3(newX, newY, pos.z);
    }

    void UpdateLifetime()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") == false)
        {
            return;
        }

        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateLifetime();
    }
}
