using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public enum InputMethod
{
    KeyboardInput,
    TouchInput

}
public class Player : MonoBehaviour
{

    public GameObject warningPopUp;
    public GameObject backToMenuPopUp;
    private bool backToMenuShow = true;

    public Text scoreText;

    public int lives = 1;
    public float moveSpeed = 600f;

    float movement = 1f;
    private int currentScore;
    private int bestScore;
    private bool isCoroutineExecuting = false;

    public AdManager adManager;
    private int adChance;



    public InputMethod inputType = InputMethod.TouchInput;

    void Awake()
    {
        adChance = Random.Range(0, 4);
        if (adChance >= 3)
        {
            adManager.RequestInterstitial();
        }
       
    }
    void Start()
    {


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore", 0);    

        }   
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;
        backToMenuShow = false;
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        backToMenuPopUp.SetActive(false);

        isCoroutineExecuting = false;
    }

    public void setScores()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.SetInt("BestScore", bestScore);
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            currentScore = (int)Time.timeSinceLevelLoad;
            scoreText.text = "Time: " + currentScore;
        }
           
        if (inputType == InputMethod.KeyboardInput)
        {
            KeyboardInput();
        }
        
            
        else if (inputType == InputMethod.TouchInput)
        {
            TouchInput();
        }    

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {

            if (currentScore > bestScore)
            {
                bestScore = currentScore;
            }
            setScores();
            GPlayServices.PostToLeaderboard(PlayerPrefs.GetInt("BestScore", 0) * 1000);
            
            loadlevel("GameOverScene");
            
            
            
            adManager.ShowInterstitialAd();
            //adManager.DestroyInterstitialAd();
            
            
        }
        else
        {
            warningPopUp.SetActive(true);
            backToMenuPopUp.SetActive(backToMenuShow);
            StartCoroutine(ExecuteAfterTime(7));
        }

    }

    public void loadlevel(string level)
    {
        SceneManager.LoadScene(level);
        
    }

    #region KEYBOARD
    void KeyboardInput()
    {
        //movement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("left"))
            transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * moveSpeed/5);
        else if (Input.GetKey("right"))
            transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed/5);

    }
    #endregion

    #region TOUCH
    void TouchInput()
    {

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && 
            if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x < Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * moveSpeed / 2);
            }
            else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x >= Screen.width / 2)
            {
                transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed / 2);
            }
        }

       
    
    }
    #endregion


}
