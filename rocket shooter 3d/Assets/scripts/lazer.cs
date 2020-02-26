using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    
    Transform target;
    public GameObject spark;
    Quaternion angle;
    public GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        angle = Quaternion.Euler(0f, 0f, 180f);
        InvokeRepeating("showSpark",1f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!manager.screenPressed) {
            Destroy(gameObject);
        }
        if (GameObject.FindGameObjectWithTag("playerTopPos") != null) {
            target = GameObject.FindGameObjectWithTag("playerTopPos").transform;
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        }
       

    }
    
    public void destroyME() {
        Destroy(gameObject);
    }
    void showSpark() {
        GameObject go = Instantiate(spark, pos.transform.position, angle);
        Destroy(go, 0.2f);
    }
}
