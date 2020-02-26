using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class frameManager : MonoBehaviour
{
    public GameObject[] frames;
    public GameObject[] endFrame;
    int framePointer;
    Vector3 pos;
    int rand;
    float finalPos = 50f;
    int totalHurdel=0;
    //bool lastFrameSpawned = false;
    public GameObject nextLevelScreen;
    public Image levelSlider;
    Transform playerPOS;
   // bool lvlClear = false;
    public int totalDiffrentFrame=2;
    int low, high;
    int angl = 0;
   // bool onlyOnce = false;
    public GameObject pole;
    public static bool veryFirst=true,newLvl = false;
    public static int frameNo;
    public static int startFrame;
   
    // Start is called before the first frame update
    void Start()
    {
        
        FindAFrame();
        checkForGameLevel();
        spawnAFrame(startFrame);
    }
   
    void FindAFrame() {
        if (veryFirst == true)
        {
            startFrame = Random.Range(0, totalDiffrentFrame);
            veryFirst = false;
        }
        else {
            if (newLvl) {
                int i = startFrame;
                int f= Random.Range(0, totalDiffrentFrame);
                if (i != f)
                {
                    startFrame = f; newLvl = false;
                }
                else { FindAFrame(); }
            }
        }
        

    }
    void spawnAFrame(int i) {
       
        int m = i;
        i *= 5;
        low = i;
        high = low + 4;
        pos = new Vector3(0f, 0f, 0f);
        for (int ii = 0; ii < totalHurdel; ii++)
        {
            if (ii==0|| ii == 1)
            {
                Instantiate(frames[low], pos, Quaternion.Euler(0f, angl, 0f));
                angl += 95;
                framePointer += 10;
                pos = new Vector3(0f, framePointer, 0f);
            }
            else{
                rand = Random.Range(low, high);
                Instantiate(frames[rand], pos, Quaternion.Euler(0f, angl, 0f));
                angl += 95;
                framePointer += 10;
                pos = new Vector3(0f, framePointer, 0f);
            }
               
        }
        
        Instantiate(endFrame[m], pos, Quaternion.Euler(0f, angl, 0f));
    }
    // Update is called once per frame
    void Update()
    {
        if (manager.gameStart) {
           
            
            if (GameObject.FindGameObjectWithTag("Player")!=null) {
                playerPOS = GameObject.FindGameObjectWithTag("Player").transform;
                levelSlider.fillAmount = playerPOS.transform.position.y/ finalPos;
                
                /*if (playerPOS.transform.position.y > finalPos && lvlClear == false)
                {
                    if (!onlyOnce)
                    {
                        onlyOnce = true;
                        player.powerup = false;
                        cameraFollow.followPlayer = false;
                        Invoke("showNextScreen", 1f);
                        
                        player.levelCleared = true;
                    }
                    //lvlClear = true;
                }*/
            }
            
        }
    }

    void checkForGameLevel() {
        int lvl = PlayerPrefs.GetInt("gameLevel");
        checkForGameTime(lvl);
    }
    void checkForGameTime(int lvl) {
        if (lvl < 5)
        {
            totalHurdel = 5;
            finalPos = 50;
            pole.transform.localScale =new Vector3(1f,56f,1f);
        }
        else if (lvl >= 5 && lvl < 15)
        {
            totalHurdel = 10;
            finalPos = 100;
            pole.transform.localScale = new Vector3(1f, 106f, 1f);
        }
        else if (lvl >= 15 && lvl < 25)
        {
            totalHurdel = 15;
            finalPos = 150;
            pole.transform.localScale = new Vector3(1f, 156f, 1f);
        }
        else if (lvl >= 25 && lvl < 55)
        {
            totalHurdel = 17;
            finalPos = 170;
            pole.transform.localScale = new Vector3(1f, 176f, 1f);
        }
        else {
            totalHurdel = 20;
            finalPos = 200;
            pole.transform.localScale = new Vector3(1f, 206f, 1f);
        }

        //levelSlider.minValue = -10f;
        //levelSlider.maxValue = finalPos;
        //levelSlider.value = -10f;


    }
   /* public void spawnAFrame()
    {
        if (manager.gameStart&&lvlClear==false )
        {
            framePointer += 10;
            pos = new Vector3(0f, framePointer, 0f);
            rand = Random.Range(low, high);
            Instantiate(frames[rand], pos, Quaternion.identity);
        }
        else {
            if (lastFrameSpawned == false)
            {
                lastFrameSpawned = true;
                framePointer += 10;
                pos = new Vector3(0f, framePointer, 0f);
                Instantiate(frames[frames.Length-1], pos, Quaternion.identity);
            }
            else {
                player.powerup = false;
                cameraFollow.followPlayer = false;
                Invoke("showNextScreen",1f);
                player pl = GameObject.FindObjectOfType(typeof(player)) as player;
                pl.levelCleared = true;
            }
            
        }
    }*/
    public void showNextScreen() {
        Invoke("showNow",1);
    }
    void showNow() {
        nextLevelScreen.SetActive(true);
    }
    
}
//PlayerPrefs.GetInt("gameLevel");