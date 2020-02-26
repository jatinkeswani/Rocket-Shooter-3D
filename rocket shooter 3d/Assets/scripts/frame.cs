using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame : MonoBehaviour
{
    // bool onlyOnce = false;
    public GameObject[] myParts;
    GameObject target;
    float offset;
    bool onlyOnce = false;
    void Start()
    {
        offset = 10f;
    }
    /* void OnTriggerEnter(Collider other) {
         if (other.CompareTag("Player"))
         {
             if (onlyOnce==false)
             {
                 onlyOnce = true;
                 //frameManager adscrpt = GameObject.FindObjectOfType(typeof(frameManager)) as frameManager;
                 //adscrpt.spawnAFrame();
             }

         }
     }*/
    void Update() {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target!=null) {
            if (transform.position.y + offset < target.transform.position.y)
            {
                Destroy(gameObject);
            }
            if (onlyOnce==false)
            {
                float distance = transform.position.y - target.transform.position.y;
                if (distance < 20) { activateMyPart(); onlyOnce = true; }
            }
            

        }
        
    }

    void activateMyPart() {
        for (int i = 0; i < myParts.Length; i++)
        {
            myParts[i].SetActive(true);
        }
    }
}
