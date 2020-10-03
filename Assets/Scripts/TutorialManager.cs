using System.Collections;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    
    public GameObject[] popUps;
    private int popUpIndex = 0;
    public GameObject spawner;
    private bool isCoroutineExecuting = false;
    float movement = 1f;
    public float moveSpeed = 600f;

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


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (popUpIndex == 0)
            {
                if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x >= Screen.width / 2)
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed / 2);
                    popUps[popUpIndex].SetActive(false);
                    popUpIndex++;
                    popUps[popUpIndex].SetActive(true);
                }
            }
            else if (popUpIndex == 1)
            {
                if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touch.position.x < Screen.width / 2)
                {
                    transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * moveSpeed / 2);
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
