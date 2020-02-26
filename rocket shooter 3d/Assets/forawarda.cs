using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forawarda : MonoBehaviour
{
    float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("highSpeed",1f);
        Destroy(gameObject,20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * speed;
    }
    void highSpeed() {
        speed = 20f;
    }
}
