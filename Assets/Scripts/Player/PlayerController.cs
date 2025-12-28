using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동과 점프에 사용할 변수")]
    public float moveSpeed = 5.0f;  // 이동 시 사용할 속력.
    public float jumpSpeed = 8.0f;  // 점프 시 사용할 속력.

    [Header("물리 컴포넌트")]
    public Rigidbody2D rb;

    private bool isGrounded = false;    // 지면에 착지한 상태인지 여부.

    private float moveInput = 0.0f; // 좌우 키 입력 값을 저장하기 위한 변수.
    private bool jumpRequested = false; // 점프 키를 눌렀는지 여부.

    // Update is called once per frame
    void Update()
    {
        // 키 입력 처리.
        HandleMoveInput();
        HandleJumpInput();
        UpdateDirection();
    }

    /// <summary>
    /// 0.02초마다 고정간격으로 호출.
    /// 물리나 중력 관련 처리를 할 때 사용하는 것이 좋다.
    /// </summary>
    void FixedUpdate()
    {
        // 실제 이동/점프 처리.
        ApplyMovement();
    }

    void HandleMoveInput()
    {
        // 좌우 방향 키 입력 값을 가져와서 변수에 저장한다.
        // 왼쪽 키 클릭 시 0보다 작은 값(-1), 오른쪽 키 클릭 시 0보다 큰 값(1), 키를 누르지 않으면 0을 반환.
        moveInput = Input.GetAxis("Horizontal");
    }

    void HandleJumpInput()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && isGrounded == true)
        {
            jumpRequested = true;
        }
    }

    void ApplyMovement()
    {
        // rb에 적절한 컴포넌트가 연결되어 있지 않을 경우.
        if(rb == null)
        {
            return;
        }

        Vector2 velocity = rb.linearVelocity;
        float targetSpeedX = moveInput * moveSpeed;
        velocity.x = targetSpeedX;

        if(jumpRequested == true && isGrounded == true)
        {
            velocity.y = jumpSpeed;

            isGrounded = false;
            jumpRequested = false;

            Debug.Log("점프 실행!!!!!");
        }

        rb.linearVelocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 지면이 맞는지 먼저 체크를 해야 한다.
        // 충돌한 게임 오브젝트의 태그(Tag) 정보를 비교해서 체크.
        if(collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 지면이 맞는지 먼저 체크를 해야 한다.
        // 충돌한 게임 오브젝트의 태그(Tag) 정보를 비교해서 체크.
        if (collision.gameObject.CompareTag("Ground") == true)
        {
            isGrounded = false;
        }
    }

    void UpdateDirection()
    {
        // 게임 오브젝트의 크기 정보를 가져온다.
        Vector3 scale = transform.localScale;

        // 오른쪽.
        if(moveInput > 0.0f)
        {
            scale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (moveInput < 0.0f)  // 왼쪽.
        {
            scale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        // 크기 정보 갱신.
        transform.localScale = scale;
    }
}
