using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;

    public float moveSpeed = 2.0f;

    public float pointReachThreshold = 0.05f;

    public bool moveRight = true;
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurnAround();
        Move();
    }

    void Move()
    {
        float directionX = 0.0f;

        if(moveRight == true)
        {
            directionX = 1.0f;
        }
        else
        {
            directionX = -1.0f;
        }

        float distance = moveSpeed * Time.deltaTime * directionX;
        
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + new Vector3(distance, 0.0f, 0.0f);
        transform.position = newPosition;

        //transform.position += new Vector3(distance, 0.0f, 0.0f);

        if(animator != null)
        {
            animator.SetBool("Move", true);
        }
    }

    void CheckTurnAround()
    {
        if(leftPoint == null || rightPoint == null)
        {
            return;
        }

        float currentX = transform.position.x;

        float leftX = leftPoint.position.x;
        float rightX = rightPoint.position.x;

        if(moveRight == true)
        {
            float distanceToRight = Mathf.Abs(rightX - currentX);
            if(distanceToRight <= pointReachThreshold)
            {
                TurnAround();
            }
        }
        else
        {
            float distanceToLeft = Mathf.Abs(currentX - leftX);
            if(distanceToLeft <= pointReachThreshold)
            {
                TurnAround();
            }
        }
    }

    void TurnAround()
    {
        if(moveRight == true)
        {
            moveRight = false;
        }
        else if(moveRight == false)
        {
            moveRight = true;
        }

        //moveRight = !moveRight;
        //moveRight = (moveRight == false);

        if(spriteRenderer != null)
        {
            if(moveRight == true)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
