using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;

    public static UIManager Instance { get; private set; }
    
    private void Awake()
    {
        // ensure there's only one GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    
    public void UpdateScoreUI()
    {
        // level 1 Score UI
        if (GameManager.Instance.score == 0)
            scoreText.text = "00000" + GameManager.Instance.score;
        else if (GameManager.Instance.score >= 100 && GameManager.Instance.score < 1000)
            scoreText.text = "000" + GameManager.Instance.score;
        else
            scoreText.text = "00" + GameManager.Instance.score;
    }

    public void UpdateLivesUI()
    {
        // Lives UI
        if (GameManager.Instance.lives == 3)
            livesText.text = "Lives: III";
        else if (GameManager.Instance.lives == 2)
            livesText.text = "Lives: II";
        else if (GameManager.Instance.lives == 1)
            livesText.text = "Lives: I";
    }
}
