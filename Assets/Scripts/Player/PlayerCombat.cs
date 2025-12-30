using UnityEngine;

/// <summary>
/// 플레이어의 기본 공격을 담당하는 클래스.
/// 공격 키 입력을 감지.
/// 공격 쿨타임 관리.
/// 공격 애니메이션 재생.
/// </summary>
public class PlayerCombat : MonoBehaviour
{
    [Tooltip("공격 입력 키 지정 변수")]
    public KeyCode attackKey = KeyCode.J;   // 공격 입력 키 지정.

    public float attackCooldown = 0.5f; // 다음 공격 가능 시간까지 도달하기 위한 쿨타임.

    public Animator animator;

    private float attackTimer;  // 공격 쿨타임 체크를 위한 타이머 변수.
    private bool isAttacking;   // 현재 공격중인지 여부.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackTimer = 0.0f;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttackTimer();
        HandleAttackInput();
    }

    /// <summary>
    /// 공격 쿨타임 타이머를 체크하기 위한 함수.
    /// </summary>
    void UpdateAttackTimer()
    {
        if(attackTimer > 0.0f)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0.0f)
            {
                attackTimer = 0.0f;
                isAttacking = false;
            }
        }
    }

    /// <summary>
    /// 공격 키 입력을 받아 공격 상태로 전환.
    /// </summary>
    void HandleAttackInput()
    {
        if(Input.GetKeyDown(attackKey) == true && attackTimer <= 0.0f)
        {
            StartAttack();
        }
    }

    /// <summary>
    /// 공격 시작.
    /// </summary>
    void StartAttack()
    {
        if(animator == null)
        {
            return;
        }

        animator.SetTrigger("Attack");

        attackTimer = attackCooldown;
        isAttacking = true;
    }
}
