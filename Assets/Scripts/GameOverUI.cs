using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameResultUI;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;

    private void Start()
    {
        scoreUI.text = "Final Score: " + GameManager.Instance.score;
        highScoreUI.text = "High Score: " + GameManager.Instance.highScore;
        
        if (GameManager.Instance.gameWon)
        {
            gameResultUI.text = "Game Complete!";
            gameResultUI.color = Color.green;
        }
        else
        {
            gameResultUI.text = "Game Over!";
            gameResultUI.color = Color.red;
        }
    }

    public void PlayAgain()
    {
        GameManager.Instance.LoadLevel1();
    }

    public void MainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
