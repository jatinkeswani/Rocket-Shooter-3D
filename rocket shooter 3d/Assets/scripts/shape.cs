using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shape : MonoBehaviour
{
    public GameObject[] parts;
    bool onlyOnce=false;
    Animation an;
    public bool startMoving = false;
    Transform core;
    public bool blackShape = true;
    Renderer m;
    public float x, z;
    bool desCmd = false;
    Rigidbody rb;
    bool goDown = false;
    MeshCollider mc;
    bool falling = false;
    public bool levelClear=false;
    int lef;
    
    void Start()
    {
        mc= GetComponent<MeshCollider>();
        m = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        an = GetComponent<Animation>();
        x += x;
        z += z;
        //core = transform.position + new Vector3(x,-100f,z);
        if (blackShape) rb.mass = 100;
        lef = Random.Range(1,3);
        
    }
    void Update() {
        if (blackShape == false) {
            m.material.color = colorManager.mainColor;
        }
        if (startMoving&&falling==false) {
           
            if (lef == 1) { core = GameObject.FindGameObjectWithTag("right").transform; }
            if (lef == 2) { core = GameObject.FindGameObjectWithTag("left").transform; }
           
            transform.position = Vector3.MoveTowards(transform.position,core.position,  20f * Time.deltaTime);
            transform.Rotate(1f, 1f, 1f);
            if (!desCmd) {
                Destroy(gameObject, 1f); desCmd = true;
            }
        }
        if (goDown) {
            falling = true;
            transform.position += Vector3.down * 15f * Time.deltaTime;
           // transform.Rotate(5f,0f,0f);
        }
    }
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            if (blackShape == false || (blackShape == true && player.powerup == true))
            {
                if (!onlyOnce)
                {
                    blockSoundManager sm = GameObject.FindObjectOfType(typeof(blockSoundManager)) as blockSoundManager;
                    sm.tapSound();
                    // Destroy(other.gameObject);
                    applyForce();
                    startMoving = true;
                    if (levelClear) {
                        player.levelCleared = true; player.powerup = false; cameraFollow.followPlayer = false;
                        frameManager pl = GameObject.FindObjectOfType(typeof(frameManager)) as frameManager;
                        pl.showNextScreen();
                    }
                    //bulletStrike = true;
                    onlyOnce = true;
                    // an.enabled = true;
                    manager mn = GameObject.FindObjectOfType(typeof(manager)) as manager;
                    mn.increaseScore();
                }
            }
            if (blackShape == true && player.powerup == false)
            {
                blockSoundManager sm = GameObject.FindObjectOfType(typeof(blockSoundManager)) as blockSoundManager;
                sm.tapSound();
                goDown = true;
                mc.isTrigger = false;
            }
        }
        
       
       
    }

    void OnCollisionEnter(Collision other)
    {


        if (other.gameObject.CompareTag("lazer"))
        {
            Destroy(gameObject);
        }

    }
    void applyForce() {
        //an.Play("shape");
        for (int i = 0; i < parts.Length; i++)
        {
            //parts[i].GetComponent<Collider>().isTrigger = false;
           // parts[i].GetComponent<Rigidbody>().useGravity = true;
            parts[i].GetComponent<shape>().startMoving = true;
           parts[i].GetComponent<MeshCollider>().enabled = false;

        }
        
    }
    
    }
