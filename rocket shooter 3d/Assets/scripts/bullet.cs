using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject spark;

    Quaternion angle, angle2;
    Vector3 offset;
    float speed;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject,0.2f);
        //speed = PlayerPrefs.GetInt("bulletSpeed");
        //if (speed == 0)
        //{
            speed = 50f;
       // }

        angle = Quaternion.Euler(0f, 0f, 180f);
        angle2 = Quaternion.Euler(180f, 0f, 180f);
        Destroy(gameObject, 3f);
        offset = new Vector3(0f, .5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.screenPressed)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider other)
    {

        
        if ( other.CompareTag("destroyBullet"))
        {
           
            // player.canMove = true;


            GameObject go = Instantiate(spark, transform.position, angle);
                Destroy(go, 0.1f);
            Destroy(gameObject);
            
        }
        

    }
  
}
