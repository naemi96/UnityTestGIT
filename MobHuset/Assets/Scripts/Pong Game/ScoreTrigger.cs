using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField]
    private Paddle.Side paddleThatScored;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PongBall ball = collider.GetComponent<PongBall>();

        if (ball)
        {
            GameController.instance.Score(paddleThatScored);

        }
    }
}
