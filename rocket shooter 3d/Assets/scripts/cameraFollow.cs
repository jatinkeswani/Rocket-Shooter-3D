using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
     Transform target;
    public static bool followPlayer = true;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offsetLookAt;
    float limit;
    void Start() {
        followPlayer = true;
        
    }
    void Update()
    {
        if (offset.y <= 2f) {
            offset.y += Time.deltaTime*5;
        }
        if (followPlayer) {
            
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                
                target = GameObject.FindGameObjectWithTag("Player").transform;
                limit = target.position.y;
               // if (target.position.y >= transform.position.y) {
                    Vector3 desiredPosition = target.position + offset;
                    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
                    transform.position = smoothedPosition;
               // }

              
               // transform.LookAt(target);
            }
        }
        
        
    }
    
}