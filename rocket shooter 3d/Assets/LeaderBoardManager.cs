/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class LeaderBoardManager : MonoBehaviour
{

    public static LeaderBoardManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayGamesPlatform.Activate();
        login();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void login()
    {
        Social.localUser.Authenticate((bool success) => { });
    }

    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(LeaderBoard.leaderboard_leaderboard);
        }
        else
        {
            login();
        }
    }
}*//*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public static LeaderBoardManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        AuthenticateToGameCenter();
    }
    #region GAME_CENTER

    public static void AuthenticateToGameCenter()
    {
#if UNITY_IOS
            Social.localUser.Authenticate((bool success) =>
                                      {
                if (success)
                {
                    Debug.Log("Authentication successful");
                }
                 else
                 {
                    Debug.Log("Authentication failed");
                 }
        });
#endif
    }
    public static void ReportScore(long score, string leaderboardID)
    {
#if UNITY_IOS
            //Debug.Log("Reporting score " + score + " on leaderboard " + leaderboardID);
            Social.ReportScore(score, leaderboardID, (bool success) =>
            {
                if (success)
                {
                    Debug.Log("Reported score successfully");
                }
                else
                {
                    Debug.Log("Failed to report score");
                }
 
                Debug.Log(success ? "Reported score successfully" : "Failed to report score"); Debug.Log("New Score:"+score);  
                });
#endif
    }
    public static void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
#if UNITY_IOS
            Social.ShowLeaderboardUI();
#endif
        }
        else
        {
            AuthenticateToGameCenter();
        }
    }
    #endregion
}*/
