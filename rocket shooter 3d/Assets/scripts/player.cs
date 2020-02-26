using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //public Transform[] bulletEmitter;
    public GameObject bullet;
    public Transform bulletEmitter;

    public GameObject BulletB;



    public GameObject roundEff;

    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;

    
    MuzzleFlash muzzleflash;
    float nextShotTime;

   // bool onlyOnce=false;
    public static float speed=5f;
    
    public static bool planedestroyed = false;
    public GameObject spark;
    
    public float damageFromBullet = 10f;
    public static bool levelCleared=false;
    
    public static bool powerup = false;
    public  bool canMove = true;
    public static bool powerActivatedCheck = false;
    public GameObject bigCircle;
    public static bool firstTime = true;
    //public GameObject BulletExplosion;

    public GameObject BlastEffect,blastEff2;
    bool stop = false;
    public GameObject[] myParts;
    Rigidbody rb;
    Vector3 orignalPos;
    public Collider myCollider;
    bool onlyOnce = false;
    public GameObject thrust;
    
   // public GameObject lineParticle;
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        levelCleared = false;
        firstTime = true;
        powerActivatedCheck = false;
        powerup = false;
        muzzleflash = GetComponent<MuzzleFlash>();
       // speed = PlayerPrefs.GetInt("planeSpeed");
        //Debug.Log("planeSpeed"+speed);
        //msBetweenShots = PlayerPrefs.GetInt("fireRate");
        
        speed = 8f;
        msBetweenShots = 140f;

        planedestroyed = false;
        int lvl = PlayerPrefs.GetInt("gameLevel");
        myHealth(lvl);
        //Debug.Log("speed plane"+speed);
        //Debug.Log("frame" + msBetweenShots);
    }
    void myHealth(int lvl) {
        if (lvl >= 9)
        {
            damageFromBullet = 6f;
        }
        if (lvl >= 19)
        {
            damageFromBullet = 5f;
        }
        if (lvl >= 29)
        {
            damageFromBullet = 4f;
        }
        if (lvl >= 39)
        {
            damageFromBullet = 3f;
        }
        if (lvl >= 49)
        {
            damageFromBullet = 2f;
        }
        if (lvl >= 59)
        {
            damageFromBullet = 1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.rotation = Quaternion.Euler(0f, -90f, 90f);
        //rb.freezeRotation = true;
        if (levelCleared==true)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
            
            
        }
        else {
           

                if (manager.screenPressed)
                {
                    stop = false;
                if (planedestroyed == false) {
                    transform.position += Vector3.up * Time.deltaTime * speed;
                    Shoot();
                }
                    
                    //if (canMove)
                    /* if (Myrotation >= 0)
                     {
                         transform.position += Vector3.up * Time.deltaTime * speed;
                     }
                     else {*/
                    // Myrotation -= Time.deltaTime;
                    //transform.rotation = Quaternion.EulerAngles(Myrotation, -116f, 90f);
                    /* }*/


                    //if (canFire)
                    
                }
                 else {
                     if (manager.gameStart) {
                        if (!stop)
                        {
                       
                            transform.position += Vector3.down * Time.deltaTime * speed / 3; Invoke("stopTrue", 0.2f);
                        

                            
                            
                        }
                     }

                 }
                if (powerup)
                {
                    if (manager.screenPressed == false)
                    {
                        //lineParticle.SetActive(false);
                        powerActivatedCheck = false;
                    }
                }
            
        }
       

    }
    void stopTrue()
    {
        stop = true;
    }
    public void Shoot()
    {

        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            spawnBullet();
        }
    }
    void spawnBullet() {
       // Instantiate(hiddenBullet, hiddenBulletEmitter.position, hiddenBulletEmitter.rotation);

        if (powerup)
        {
            if (!powerActivatedCheck) {
                Instantiate(roundEff, transform.position, Quaternion.identity);
                powerActivatedCheck = true;
                //lineParticle.SetActive(true);
                GameObject go= Instantiate(bigCircle, transform.position, Quaternion.identity);
                Destroy(go,2f);
                Instantiate(BulletB, bulletEmitter.position, bulletEmitter.rotation);
                muzzleflash.Activate();
               
                //GameObject go2= Instantiate(BulletExplosion, bulletEmitter.position, bulletEmitter.rotation);
                //Destroy(go2,2f);
                
            }
                
            
                soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
                sm.laserFn();
            
        }
        else {
            
            Instantiate(bullet, bulletEmitter.position, Quaternion.identity);
            muzzleflash.Activate();
            soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
            sm.fireFn();
            /*  for (int i = 0; i < bulletEmitter.Length; i++)
              {
                  Instantiate(bullet, bulletEmitter[i].position, bulletEmitter[i].rotation);
                  muzzleflash.Activate();
                  soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
                  sm.fireFn();
                  //CameraShaker.Instance.ShakeOnce(.5f, 1f, 0.1f, 0.01f);
              }*/
        }
        //Time.timeScale = 0f;
    }

   
    /*void OnCollisionEnter(Collision other)
    {
       
        
        if (other.gameObject.CompareTag("black"))
        {
           
            destroyFn();
        }
        
    }*/
        public void destroyFn() {
        //Debug.Log(planedestroyed);
        if (planedestroyed == false) {
         orignalPos = transform.position;
        soundManager sm = GameObject.FindObjectOfType(typeof(soundManager)) as soundManager;
        sm.destroyFn();
        planedestroyed = true;
            myCollider.enabled = false;
        GameObject go= Instantiate(BlastEffect,transform.position,transform.rotation);
            Destroy(go,2f);
            GameObject go2 = Instantiate(blastEff2, transform.position, transform.rotation);
            Destroy(go2, 2f);
            cameraFollow.followPlayer = false;
        manager.gameStart = false;
            // gameObject.SetActive(false);
            for (int i = 0; i < myParts.Length; i++)
            {
                myParts[i].SetActive(false);
            }

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                //no internet
                manager mn = GameObject.FindObjectOfType(typeof(manager)) as manager;
                mn.RestartScreenFn();
            }
            else {
                if (onlyOnce == false)
                {
                    onlyOnce = true; Invoke("callForContinueScreen", 1f);
                }
                else {
                    manager mn = GameObject.FindObjectOfType(typeof(manager)) as manager;
                    mn.RestartScreenFn();
                }
                
            }
        }
        
        }
    void callForContinueScreen() {
        manager mn = GameObject.FindObjectOfType(typeof(manager)) as manager;
        mn.ContinueScreenFn();
    }
    public void continueGame() {
        for (int i = 0; i < myParts.Length; i++)
        {
            myParts[i].SetActive(true);
        }
        myCollider.enabled = true;
        //planedestroyed = false;
        Invoke("planeDestroyFalse",3f);
        cameraFollow.followPlayer = true;
        manager.gameStart = true;
        

       
        orignalPos.y -= 3f;
        transform.position = orignalPos;
        rb.velocity = Vector3.zero;
    }
    void planeDestroyFalse() {
        planedestroyed = false;
    }
    public void hideThrust()
    {
        thrust.SetActive(false);
    }
    public void showThrust()
    {
        thrust.SetActive(true);
    }
}
