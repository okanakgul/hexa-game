using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;



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
    private long scoreToPost;


    public int lives = 1;
    public float moveSpeed = 600f;

    float movement = 1f;
    private int currentScore;
    private int bestScore;
    private bool isCoroutineExecuting = false;

    public AdManager adManager;
    private int randomIndex;




    public InputMethod inputType = InputMethod.TouchInput;

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore", 0);

            // Main Theme Play Randomly
            //int length = FindObjectOfType<AudioController>().sounds.Length;
            //randomIndex = Random.Range(0, length);
            //FindObjectOfType<AudioController>().Play(randomIndex);

            FindObjectOfType<audioManager>().Play();

            // 40% CHANCE FOR AD
            int adChance = Random.Range(0, 4);
            if(adChance >= 3)
            {
                adManager.RequestInterstitial();
            }
            
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



    public int getScore()
    {
        return currentScore;
    }
    // Update is called once per frame
    void Update()
    {

        // Music Loop
        /*if (!FindObjectOfType<AudioController>().sounds[randomIndex].source.isPlaying)
        {
            randomIndex = (randomIndex + 1) % 2;
            FindObjectOfType<AudioController>().Play(randomIndex);
        }*/



        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            currentScore = (int)Time.timeSinceLevelLoad;
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
            scoreToPost = PlayerPrefs.GetInt("BestScore", 0);
            loadlevel("GameOverScene");            
            adManager.ShowInterstitialAd();
            adManager.DestroyInterstitialAd();
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
