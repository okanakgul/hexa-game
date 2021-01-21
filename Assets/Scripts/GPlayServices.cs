using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;


public class GPlayServices : MonoBehaviour
{

    void Start()
    {

        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
                SceneManager.LoadScene("StartScene");
            });
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public static void PostToLeaderboard(long newScore)
    {
        Social.ReportScore(newScore, GPGSIds.leaderboard_high_scores, (bool success) =>{ });
    }

    public static void ShowLeaderboardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_scores);
    }


}
