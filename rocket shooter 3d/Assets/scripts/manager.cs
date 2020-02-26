using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
//using UnityEngine.SocialPlatforms;

public class manager : MonoBehaviour
{
    public static bool screenPressed = false;
    public static float totalHealth = 100f;
    public Image planeImage, fillImage;
    public Slider healthSlider;
    public Text healthText, scoreText, highScore, PreLvl, PostLvl;
    public GameObject hurtSlider;
    int scorePointer = 0;
    public GameObject TapToPlay, RestartScreen, ContinueScreen;
    public GameObject highScoreReached, ProMeterHolder, planeBtnGo, powerSlider;

    Animation an, an2, an3;
    int lastTimeScore;
    bool animationPlayed = false;
    public static bool gameStart = false;
    public Slider proSlider;
    public GameObject[] tick;
    public GameObject planesScreen, normalCanvas;
    public GameObject lazer;
    static int showPhotoAd = 5;
    public GameObject musicIcon;
    
    // Start is called before the first frame update
    void Start()
    {
        musicIcon.SetActive(true);
     //   if (Application.internetReachability != NetworkReachability.NotReachable)
     //   {
     //       AdViewScene sm = GameObject.FindObjectOfType(typeof(AdViewScene)) as AdViewScene;
     //       sm.LoadBanner();
     //       showPhotoAd -= 1;
     //       if (showPhotoAd==1) {
     //           InterstitialAdScene sm2 = GameObject.FindObjectOfType(typeof(InterstitialAdScene)) as InterstitialAdScene;
     //           sm2.LoadInterstitial();
     //       }
     //   }

        //PlayerPrefs.SetInt("highScore",0);
        // Application.targetFrameRate = 300;
        //PlayerPrefs.SetInt("gameLevel",60);
        //Debug.Log(PlayerPrefs.GetInt("gameLevel"));
        PlayerPrefs.GetInt("gameLevel",60);
        int lvl = PlayerPrefs.GetInt("gameLevel");
        proSlider.value = lvl;
        checkTick(lvl);
        an = ProMeterHolder.GetComponent<Animation>();
        an2 = planeBtnGo.GetComponent<Animation>();
        an3 = powerSlider.GetComponent<Animation>();
        scorePointer = 0;
        scoreText.text = "";
        totalHealth = 100f;
        healthSlider.value = 100;
        healthText.text = "100";
        highScore.text = "" + PlayerPrefs.GetInt("highScore");
        lastTimeScore = PlayerPrefs.GetInt("highScore");
        checkLevels();
        pointerUp();
    }
    void checkTick(int lvl) {
        if (lvl >= 9)
        {
            tick[0].SetActive(true);
        }
        if (lvl >= 19)
        {
            tick[1].SetActive(true);
        }
        if (lvl >= 29)
        {
            tick[2].SetActive(true);
        }
        if (lvl >= 39)
        {
            tick[3].SetActive(true);
        }
        if (lvl >= 49)
        {
            tick[4].SetActive(true);
        }
        if (lvl >= 59)
        {
            tick[5].SetActive(true);
        }
    }
    void checkLevels() {
        int lvl = PlayerPrefs.GetInt("gameLevel");
        lvl += 1;
        PreLvl.text = "" + lvl;
        lvl += 1;
        PostLvl.text = "" + lvl;
    }

    public void pointerDown()
    {
        screenPressed = true;
        if (gameStart == false) {
            TapToPlay.SetActive(false);
            gameStart = true;
            an.Play("PROmeterHolder");
            an2.Play("planeBtnGo");
            an3.Play("PowerUpCome");
            soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
            sm.tapSound();
            player.firstTime = false;
            lazerFollow sm2 = GameObject.FindObjectOfType(typeof(lazerFollow)) as lazerFollow;
            sm2.increaseSpeed();
            musicIcon.SetActive(false);
            
        }
    }
    public void pointerUp()
    {
        screenPressed = false;
        blockSoundManager sm = GameObject.FindObjectOfType(typeof(blockSoundManager)) as blockSoundManager;
        sm.pitchBackToNull();
    }


    public void increaseScore() {
        int r = Random.Range(1, 4);
        scorePointer += r;
        scoreText.text = "" + scorePointer;
        if (animationPlayed == false) {
            if (scorePointer > lastTimeScore)
            {
                animationPlayed = true;
                highScoreReached.SetActive(true);
                //an.Play("highScoreReached");
            }
        }

    }
    public void RestartScreenFn() {
        
        powerUPmanager pum = GameObject.FindObjectOfType(typeof(powerUPmanager)) as powerUPmanager;
        pum.backToNormal(); // power effect htane k lie
        RestartScreen.SetActive(true);
    }
    public void ContinueScreenFn()
    {
        pointerUp();
    //    if (Application.internetReachability != NetworkReachability.NotReachable)
    //    {
    //        if (showPhotoAd == 1)
    //        {
    //            showPhotoAd = 5;
    //            InterstitialAdScene sm2 = GameObject.FindObjectOfType(typeof(InterstitialAdScene)) as InterstitialAdScene;
    //            sm2.ShowInterstitial();
    //        }

    //    }
        ContinueScreen.SetActive(true);
    }
    public void continueTheGame() {
        ContinueScreen.SetActive(false);
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        float diff = p.transform.position.y - lazer.transform.position.y;
        if (diff<5)
        {
            float off = p.transform.position.y - 5;
            if(off<-12)
                lazer.transform.position = new Vector3(0f, -12.5f, -1.8f);
            else
                lazer.transform.position = new Vector3(0f, off, -1.8f);
        }
        

        player pum = GameObject.FindObjectOfType(typeof(player)) as player;
        pum.continueGame();
    }
    public void RestartBtnClicked()
    {
        
        gameStart = false;

        checkForHighScore();
        SceneManager.LoadScene("SampleScene");
    }
    public void nextLeveLButtonClicked()
    {
    //    if (Application.internetReachability != NetworkReachability.NotReachable)
    //    {
    //       if (showPhotoAd == 1)
    //        {
    //            showPhotoAd = 5;
    //            InterstitialAdScene sm2 = GameObject.FindObjectOfType(typeof(InterstitialAdScene)) as InterstitialAdScene;
    //            sm2.ShowInterstitial();
    //        }

    //    }
        soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
        sm.tapSound();
        player.powerup = false;
        frameManager.newLvl = true;
        colorManager.newClr = true;
        gameStart = false;
        checkForHighScore();
        int level= PlayerPrefs.GetInt("gameLevel");
       

        level += 1;

        //Social.ReportScore((long)level, "CgkIzLHrtZAOEAIQAA", (bool success) => { });
        PlayerPrefs.SetInt("gameLevel", level);
        SceneManager.LoadScene("SampleScene");
    }
    void checkForHighScore() {
        int scr = PlayerPrefs.GetInt("highScore");
        if (scorePointer > scr) { PlayerPrefs.SetInt("highScore", scorePointer); }
    }
  
    public void showPlanes()
    {
        player sm = GameObject.FindObjectOfType(typeof(player)) as player;
        sm.hideThrust();
        lazer.SetActive(false);
        normalCanvas.SetActive(false);
        planesScreen.SetActive(true);

    }
    public void HidePlanes()
    {
        player sm = GameObject.FindObjectOfType(typeof(player)) as player;
        sm.showThrust();
        lazer.SetActive(true);
        planesScreen.SetActive(false);
        normalCanvas.SetActive(true);
    }
    
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("video"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("video", options);
        }
        else
        {
            continueTheGame();
        }
    }
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                continueTheGame();
                break;
            case ShowResult.Skipped:
                continueTheGame();
                break;
            case ShowResult.Failed:
                continueTheGame();
                break;
        }
    }

}
//PlayerPrefs.GetInt("highScore");
//PlayerPrefs.SetInt("gameLevel", lvl);
//rotate       50    
//plane speed  5     
//fire rate    200   
//bullet speed 20 
//2331987096909094_2332002473574223 banner
//2331987096909094_2331999186907885 photo
//2331987096909094_2331990996908704 video