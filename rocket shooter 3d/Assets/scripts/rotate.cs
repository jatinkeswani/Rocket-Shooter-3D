using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float x = 0f, y = -1f, z = 0f;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
       // speed = PlayerPrefs.GetInt("rotate");
       // Debug.Log("rotate" + speed);
       
            speed = 80f;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x * Time.deltaTime * speed, y*Time.deltaTime* speed, z * Time.deltaTime * speed);
    }
}
