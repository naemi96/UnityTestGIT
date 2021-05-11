using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    [SerializeField] private UIManager uiManager;

    [SerializeField] private int ScoreToWin = 2;
    [SerializeField] private int LeftScore;
    [SerializeField] private int RightScore;

    [SerializeField] private bool inMenu;

    private PongBall ball;

    [SerializeField] private Paddle LeftPaddle;
    [SerializeField] private Paddle RightPaddle;

    private Paddle.Side serveSide;

    private void Awake()
    {
        instance = this;
        ball = GameObject.FindGameObjectWithTag("PongBall").GetComponent<PongBall>();

        Cursor.lockState = CursorLockMode.None;

        DoMenu();
    }

    private void DoMenu()
    {
        inMenu = true;
        LeftPaddle.isAI = RightPaddle.isAI = true;
        
        Cursor.visible = true; //test

        LeftScore = RightScore = 0;
        uiManager.UpdateScoreText(LeftScore, RightScore);

        ResetGame();
    }

    public void Score(Paddle.Side side)
    {
        if (side == Paddle.Side.Left)
            LeftScore++;

        else if (side == Paddle.Side.Right)
            RightScore++;

        uiManager.UpdateScoreText(LeftScore, RightScore);
        serveSide = side;

        if (IsGameOver())
        {
            if (inMenu)
            {
                ResetGame();
                LeftScore = RightScore = 0;
            }

            else
            {
                ball.gameObject.SetActive(false);
                uiManager.ShowGameOver(side);
            }
        }

        else
        {
            ResetGame();
        }

    }

    private bool IsGameOver()
    {
        bool result = false;

        if (LeftScore >= ScoreToWin || RightScore >= ScoreToWin)
            result = true;

        return result;
    }

    private void ResetGame()
    {
        ball.gameObject.SetActive(true);
        ball.Reset(serveSide);
        LeftPaddle.Reset();
        RightPaddle.Reset();

    }

    public void startGame()
    {
        RightPaddle.isAI = true;
        LeftPaddle.isAI = false;

        InitializeGame();
    }

    public void Replay()
    {
        InitializeGame();
        uiManager.OnGameStart();
    }

    public void GoToMenu()
    {
        uiManager.ShowMenu();
        DoMenu();
    }

    public void QuitPongGame()
    {
        //Application.Quit();

        SceneManager.LoadScene(2);
    }

    private void InitializeGame()
    {
        inMenu = false;
        LeftScore = RightScore = 0;
        uiManager.UpdateScoreText(LeftScore, RightScore);
        ResetGame();
        uiManager.OnGameStart();
    }
}

