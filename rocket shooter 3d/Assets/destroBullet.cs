using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroBullet : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("playerTopPos") != null)
        {
            target = GameObject.FindGameObjectWithTag("playerTopPos").transform;
            
            transform.position = Vector3.Lerp(transform.position, target.position, 0.1f);
        }
    }
    
}
