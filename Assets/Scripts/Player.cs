using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
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

    public int lives = 1;
    public float moveSpeed = 600f;

    float movement = 1f;
    static private int gameScore;
    private bool isCoroutineExecuting = false;

    public InputMethod inputType = InputMethod.TouchInput;

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

    public int getScore()
    {
        return gameScore;
    }
    // Update is called once per frame
    void Update()
    {


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            gameScore = (int)Time.timeSinceLevelLoad;
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
            loadlevel("GameOverScene");
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
