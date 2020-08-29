using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TextEditor : MonoBehaviour
{
    public Player player;
    private int gameScore;
    public Text scoreText;
    // Start is called before the first frame update
    private int minutes, seconds;

    private void changeText()
    {        
        seconds = gameScore % 60;
        if (gameScore >= 60)
        {
            minutes = gameScore / 60;
            scoreText.text = minutes + " minutes " + seconds + " seconds";
        }
        else
        {
            scoreText.text = seconds + " seconds";
        }
    }

    void Start()
    {
        gameScore = player.GetComponent<Player>().getScore();
    }
    void Update()
    {
        changeText();

    }
}
