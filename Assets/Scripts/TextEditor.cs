using UnityEngine;
using UnityEngine.UI;



public class TextEditor : MonoBehaviour
{

    private int gameScore;
    private int bestScore;
    public Text scoreText;
    public Text bestScoreText;
    public Text recordText;
    public float timer;
    // Start is called before the first frame update
    private int minutes, seconds;


    void Start()
    {
        gameScore = PlayerPrefs.GetInt("CurrentScore", 0);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        changeText(scoreText, gameScore);
        changeText(bestScoreText, bestScore);
        recordText.enabled = false;
    }

    private void blinkingText(Text text)
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.5)
        {
            text.enabled = true;
        }
        if (timer >= 1)
        {
            text.enabled = false;
            timer = 0;
        }
    }

    private void changeText(Text text, int score)
    {
        seconds = score % 60;
        if (score >= 60)
        {
            minutes = score / 60;
            text.text = minutes + " minutes " + seconds + " seconds";
        }
        else
        {
            text.text = seconds + " seconds";
        }
    }

    void Update()
    {
        if (gameScore >= bestScore)
        {
            Debug.Log("Aasd");
            changeText(bestScoreText, bestScore);
            blinkingText(recordText);
        }

    }
}
