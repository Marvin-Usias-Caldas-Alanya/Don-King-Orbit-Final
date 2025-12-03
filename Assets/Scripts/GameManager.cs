using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score;
    public int lives = 3;
    public int highScore;
    public bool gameWon;
    
    private void Awake()
    {
        // ensure there's only one GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void LoseLife()
    {
            lives--;
            UIManager.Instance.UpdateLivesUI();
            if(score > highScore)
                highScore = score; 

            if (lives <= 0)
                LoadGameOver();
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        UIManager.Instance.UpdateScoreUI();
    }

    public void ReachedFinishLine()
    {
        AddScore(1000);
        gameWon = true;
        if(score > highScore)
            highScore = score; 
        
        LoadGameOver();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
}
