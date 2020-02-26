using UnityEngine.UI;
using UnityEngine;
using EZCameraShake;
public class powerUPmanager : MonoBehaviour
{
    //public Slider powerUp;
    public Image powerUp;
    //public Image powerUPimage;
    float powerUPValue = 0f;
    bool powerActivated=false;
    public GameObject alert;
    public GameObject myScreen;
    public float myScreenTime;
    public GameObject musicBtn;
    public float musicBtnTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("activateScreen", myScreenTime); Invoke("activateMusicBtn", musicBtnTime);
        Time.timeScale = 1f;
        powerUPValue = 0f;
        powerUp.color = Color.white;
    }
    void activateScreen() {
        myScreen.SetActive(true);
    }
    void activateMusicBtn()
    {
        musicBtn.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {


        if (powerActivated == false)
        {
            if (manager.screenPressed)
            {
                powerUPValue += Time.deltaTime/7;
                powerUp.fillAmount = powerUPValue;
                if (powerUPValue >= 0.5)
                {
                    powerUp.color = Color.green;
                    powerActivated = true;
                    player.powerup = true;
                   // manager m = GameObject.FindObjectOfType(typeof(manager)) as manager;
                    //m.playerFullHealth();
                    soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
                    sm.powerUpFn();
                    CameraShaker.Instance.ShakeOnce(1f, 2f, 1f,.1f);
                   // CameraShaker.Instance.ShakeOnce()
                    
                }
            }
            else
            {
                if (powerUPValue >0)
                {
                    powerUPValue -= Time.deltaTime/7;
                    powerUp.fillAmount = powerUPValue;
                }


            }
        }
        else {
            if (powerUPValue > 0)
            {
                powerUPValue -= Time.deltaTime/12;
                powerUp.fillAmount = powerUPValue;
                if (powerUPValue <= 0.2)
                {
                    alert.SetActive(true);
                }
                    if (powerUPValue<=0)
                {
                    Time.timeScale = 1f;
                    alert.SetActive(false);
                    powerUp.color = Color.white;
                    powerActivated = false;
                   
                    player.powerup = false;
                    player.powerActivatedCheck = false;
                    lazer l = GameObject.FindObjectOfType(typeof(lazer)) as lazer;
                    if(l!=null)
                    l.destroyME();
                }
            }
        }


        

    }
    public void backToNormal() {
        powerUp.fillAmount = 0;
        powerActivated = false;
        player.powerup = false;
    }

    
}
