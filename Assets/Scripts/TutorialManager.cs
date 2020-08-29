using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class TutorialManager : MonoBehaviour
{

    
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject spawner;
    private bool isCoroutineExecuting = false;

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        popUps[popUpIndex].SetActive(false);
        popUps[popUpIndex + 1].SetActive(false);
        isCoroutineExecuting = false;
    }
    void Start()
    {
        spawner.SetActive(false);
        popUps[0].SetActive(true);
        popUps[1].SetActive(false);
        popUps[2].SetActive(false);
        popUps[3].SetActive(false);
        popUps[4].SetActive(false);
        popUps[5].SetActive(false);

    }
    void Update()
    {


        if (true)
        {
            //Touch touch = Input.GetTouch(0);
            if (popUpIndex == 0)
            {
                if ((Input.GetKeyDown(KeyCode.RightArrow)) /*|| (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x > Screen.width / 2*/)
                {


                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            else if (popUpIndex == 1)
            {
                if ((Input.GetKeyDown(KeyCode.LeftArrow)) /*|| (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x < Screen.width / 2*/)
                {
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                    popUps[popUpIndex + 1].SetActive(true);
                    spawner.SetActive(true);
                    StartCoroutine(ExecuteAfterTime(4));
                }
            }
        }
    }
}
