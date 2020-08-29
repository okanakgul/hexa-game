using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AdManager : MonoBehaviour, IUnityAdsListener
{

    Player player;
    private int score;
    private int lives;

    //private string gameId = "c6b5a194-adbf-4af2-ba63-5920ad00f1d7";

    Button myButton;
    public string myPlacementId = "rewardedVideo";

    void Start()
    {

        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
       // Advertisement.Initialize(gameId);

        //score = player.GetComponent<Player>().getScore();
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo ()
    {
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady( string placementId)
    {
        if(placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {

        } else if(showResult == ShowResult.Skipped)
        {

        } else if(showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError (string message)
    {
        Debug.LogError("Ad Error");
    }

    public void OnUnityAdsDidStart (string placementId)
    {

    }



}
