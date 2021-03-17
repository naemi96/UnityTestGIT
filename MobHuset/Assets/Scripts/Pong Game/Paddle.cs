using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed = 5f;

    public bool isAI;

    private PongBall ball;
    private BoxCollider2D col; //Changed from BoxCollider2D

    private float randomYOffset;

    private Vector2 forwardDirection;
    private bool firstIncoming;

    private bool OverridePosition;

    public enum Side { Left, Right }

    [SerializeField]
    private Side side;

    [SerializeField]
    private float resetTime;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("PongBall").GetComponent<PongBall>();
        col = GetComponent<BoxCollider2D>();

        if (side == Side.Left)
        {
            forwardDirection = Vector2.right;
        }
        else if (side == Side.Right)
        {
            forwardDirection = Vector2.left;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!OverridePosition)
        {
            MovePaddle();
        }
    }

    private void MovePaddle()
    {

        float targetYposition = GetNewYPosition();
        ClampPosition(ref targetYposition);
        transform.position = new Vector3(transform.position.x, targetYposition, transform.position.z);
    }

    private void ClampPosition(ref float yPosition)
    {
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height)).y;


        yPosition = Mathf.Clamp(yPosition, minY, maxY);
    }

    private float GetNewYPosition()
    {
        float result = transform.position.y;

        if (isAI)
        {
            if (BallIncoming())
            {
                if (firstIncoming)
                {
                    firstIncoming = false;
                    randomYOffset = GetRandomOffset();
                }

                result = Mathf.MoveTowards(transform.position.y, ball.transform.position.y + randomYOffset, moveSpeed);
            }
            else
            {
                firstIncoming = true;
            }

        }

        else
        {
            float movement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

            result = transform.position.y + movement;
        }

        return result;
    }

    private bool BallIncoming()
    {
        float dotP = Vector2.Dot(ball.velocity, forwardDirection);

        return dotP < 0f;
    }

    private float GetRandomOffset()
    {
        float maxOffset = col.bounds.extents.y;
        return Random.Range(-maxOffset, maxOffset);
    }

    public void Reset()
    {
        StartCoroutine(ResetRoutine());
    }

    private IEnumerator ResetRoutine()
    {
        OverridePosition = true;
        float startPosition = transform.position.y;
        for (float timer = 0; timer < resetTime; timer += Time.deltaTime)
        {
            float targetPosition = Mathf.Lerp(startPosition, 0f, timer / resetTime);
            transform.position = new Vector3(transform.position.x, targetPosition, transform.position.z);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        OverridePosition = false;
    }
}
