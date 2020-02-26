using UnityEngine.UI;
using UnityEngine;

public class planeSelecter : MonoBehaviour
{
    public GameObject[] planes;
    public Button[] buttons;
    public Text[] planeText;
    public Text mainText;
    Animation an,an2,anPre,anNext;
    string msg;
    public GameObject tick, warning;
    bool success=false;
    public GameObject soundOff, soundOn;
    int scrollPointer=1;
    public GameObject SCrollOBj;
    public Button PRE, NXT;
    public GameObject PREan, NXTan;
    public GameObject otherGames;
    // Start is called before the first frame update
    void Start()
    {
        
        PRE.interactable = false;
        tick.SetActive(false);
        warning.SetActive(false);
        msg = "";
        an = mainText.GetComponent<Animation>();
        an2 = SCrollOBj.GetComponent<Animation>();
        anPre = PREan.GetComponent<Animation>();
        anNext = NXTan.GetComponent<Animation>();
        CheckForSound();
        planePointerFn();
    }
    
    public void planePointerFn() {
        int pnt= PlayerPrefs.GetInt("planePointer");
        if(pnt==0) ActivatePlane(0);
        if (pnt == 1) ActivatePlane(1);
        if (pnt == 2) ActivatePlane(2);
        if (pnt == 3) ActivatePlane(3);
        if (pnt == 4) ActivatePlane(4);

    }
    
    public void selecctAPlane(int i) {
        int lvl= PlayerPrefs.GetInt("gameLevel");
        if (i == 0) {
            success = true;
            ActivatePlane(0);
            PlayerPrefs.SetInt("planePointer",0);
            msg = "SELECTED";
            showMsgFn();
        } else if (i == 1) {
            if (lvl >= 10)
            {
                ActivatePlane(1); success = true;
                PlayerPrefs.SetInt("planePointer", 1);
                msg = "SELECTED";
                showMsgFn();
            }
            else { msg = " CLEAR LEVEL 10"; showMsgFn(); success = false; }
        }else if (i == 2)
        {
            if (lvl >= 20)
            {
                ActivatePlane(2); success = true;
                PlayerPrefs.SetInt("planePointer", 2);
                msg = "SELECTED";
                showMsgFn();
            }
            else { msg = " CLEAR LEVEL 20"; showMsgFn(); success = false; }
        }
        else if (i == 3)
        {
            if (lvl >= 40)
            {
                ActivatePlane(3); success = true;
                PlayerPrefs.SetInt("planePointer", 3);
                msg = "SELECTED";
                showMsgFn();
            }
            else { msg = " CLEAR LEVEL 40"; showMsgFn(); success = false; }
        }
        else if (i == 4)
        {
            if (lvl >= 50)
            {
                PlayerPrefs.SetInt("planePointer", 4);
                ActivatePlane(4); success = true;
                msg = "SELECTED";
                showMsgFn();
            }
            else { msg = "CLEAR LEVEL 50"; showMsgFn(); success = false; }
        }
    }
    void ActivatePlane(int x) {
        //activate planes
        for (int i = 0; i < planes.Length; i++)
        {
            if (i == x)
                planes[i].SetActive(true);
            else
                planes[i].SetActive(false);
        }
        //change color of button
      /*  for (int i = 0; i < planes.Length; i++)
        {
            if (i == x)
                buttons[i].GetComponent<Image>().color = Color.green;
            else
                buttons[i].GetComponent<Image>().color = Color.white;
        }*/
        //change text
        for (int i = 0; i < planes.Length; i++)
        {
            if (i == x)
                planeText[i].text = "SELECTED";
            else
                planeText[i].text = "SELECT";
        }
    }
    void showMsgFn() {
        an.Play("planeText3D");
        Invoke("showMsg",0.5f);
    }
    void showMsg() {
        if (success)
        {
            tick.SetActive(true);
            warning.SetActive(false);
        }
        else {
            tick.SetActive(false);
            warning.SetActive(true);
        }
        mainText.text = msg;
        an.Play("planeText3Dcome");
    }


    public void CheckForSound()
    {

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            AudioListener.volume = 0f;
            soundOff.SetActive(true);
            soundOn.SetActive(false);
        }
        else
        {
            AudioListener.volume = 1f;
            soundOff.SetActive(false);
            soundOn.SetActive(true);
        }
    }
    public void soundOnClicked()
    {
        AudioListener.volume = 0f;
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        PlayerPrefs.SetInt("sound", 1);
        
    }
    public void soundOffClicked()
    {
        AudioListener.volume = 1f;
        soundOff.SetActive(false);
        soundOn.SetActive(true);
        PlayerPrefs.SetInt("sound", 0);
    }

    public void nextBtnClicked()
    {
        anNext.Play("PreNextBtnClicked");
        if (scrollPointer == 1) {
            an2.Play("1_2");
            scrollPointer = 2;PRE.interactable = true;
        }else if (scrollPointer == 2)
        {
            an2.Play("2_3");
            scrollPointer = 3;
        }else if (scrollPointer == 3)
        {
            an2.Play("3_4");
            scrollPointer = 4;
        }else if (scrollPointer == 4)
        {
            an2.Play("4_5");
            scrollPointer = 5;
            NXT.interactable = false;
        }

    }
    public void preBtnClicked()
    {
        anPre.Play("PreNextBtnClicked");
        if (scrollPointer == 5)
        {
            an2.Play("5_4");
            scrollPointer = 4; NXT.interactable = true;
        }
        else if (scrollPointer == 4)
        {
            an2.Play("4_3");
            scrollPointer = 3;
        }
        else if (scrollPointer == 3)
        {
            an2.Play("3_2");
            scrollPointer = 2;
        }
        else if (scrollPointer == 2)
        {
            an2.Play("2_1");
            scrollPointer = 1;
            PRE.interactable = false;
        }

    }
    public void otherGamesFn()
    {
        otherGames.SetActive(true);
    }
    public void HordenPass() {
        Application.OpenURL("https://apps.apple.com/us/app/horden-pass/id1453519752");
        //ios https://apps.apple.com/us/app/horden-pass/id1453519752
        //android  https://play.google.com/store/apps/details?id=com.IneptDevs.HordenPass&hl=en_US
    }
    public void eddyBall()
    {
        Application.OpenURL("https://apps.apple.com/us/app/eddy-ball/id1453687434");
        //ios  https://apps.apple.com/us/app/eddy-ball/id1453687434
        //android https://play.google.com/store/apps/details?id=com.IneptDevs.EddyBall&hl=en_US
    }
    public void DribbleUp()
    {
        Application.OpenURL("https://apps.apple.com/us/app/dribble-up/id1460474486");
        //ios https://apps.apple.com/us/app/dribble-up/id1460474486
        //android https://play.google.com/store/apps/details?id=com.IneptDevs.DribbleUp&hl=en_US
    }
    public void moreGames()
    {
        Application.OpenURL("https://apps.apple.com/us/developer/ravi-vohra/id1448125379");
        //ios https://apps.apple.com/us/developer/ravi-vohra/id1448125379
        //android https://play.google.com/store/apps/developer?id=Inept&hl=en_US
    }
    public void closeOtherGames() {
        otherGames.SetActive(false);
    }
    public void exitGame() {
        Application.Quit();
    }
}
//PlayerPrefs.GetInt("planePointer");