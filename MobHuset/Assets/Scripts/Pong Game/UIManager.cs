using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LeftScoreText;
    [SerializeField] private TextMeshProUGUI RightScoreText;

    [SerializeField] private FadeableUI menuUI;
    [SerializeField] private FadeableUI gameOverUI;

    [SerializeField] private TextMeshProUGUI winnerText;

    private void Start()
    {
        menuUI.FadeIn(true);
        gameOverUI.FadeOut(true);
    }

    public void UpdateScoreText(int LeftScore, int RightScore)
    {
        LeftScoreText.text = LeftScore.ToString();
        RightScoreText.text = RightScore.ToString();
    }

    public void OnGameStart()
    {
        menuUI.FadeOut(false);
        gameOverUI.FadeOut(false);
    }

    public void ShowMenu()
    {
        gameOverUI.FadeOut(false);
        menuUI.FadeIn(false);
    }

    public void ShowGameOver(Paddle.Side side)
    {
        gameOverUI.FadeIn(false);

        if (side == Paddle.Side.Left)

            winnerText.text = "Spelare 1";

        else if (side == Paddle.Side.Right)

            winnerText.text = "Spelare 2";

    }
}
