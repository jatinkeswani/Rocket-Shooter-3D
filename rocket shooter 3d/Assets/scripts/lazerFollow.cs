using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazerFollow : MonoBehaviour
{
    Transform target;
    public static float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = .5f;
        
    }
    public void increaseSpeed() {
        Invoke("now",2f); 
    }
    void now()
    {
        speed = 3.5f;
    }
    // Update is called once per frame
    void Update()
    {
        if (manager.gameStart && player.levelCleared ==false && player.planedestroyed == false)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (transform.position.y >= target.transform.position.y)
            {
               
                    player sm = GameObject.FindObjectOfType(typeof(player)) as player;
                    sm.destroyFn();
                
            }
        }
        

    }
   
}
