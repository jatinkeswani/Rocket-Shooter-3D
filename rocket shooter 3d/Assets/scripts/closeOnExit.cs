using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeOnExit : MonoBehaviour
{
    public bool planes=false, otherGames = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (planes == true)
            {
                manager pum = GameObject.FindObjectOfType(typeof(manager)) as manager;
                pum.HidePlanes();
            }
            if (otherGames == true)
            {
                planeSelecter pum = GameObject.FindObjectOfType(typeof(planeSelecter)) as planeSelecter;
                pum.closeOtherGames();
            }
        }
    }
}
