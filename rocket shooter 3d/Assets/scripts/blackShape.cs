using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackShape : MonoBehaviour
{
    Animation an;
    public bool startMoving = false;
    Transform core;
    bool onlyOnce = false, onlyOnce2 = false;
    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            core = GameObject.FindGameObjectWithTag("core").transform;
            transform.position = Vector3.MoveTowards(transform.position, core.position, -1 * 10f * Time.deltaTime);
            transform.Rotate(1f, 2f, 3f);
            if (!onlyOnce)
            { applyForce(); }
        }
    }
    void applyForce()
    {
        onlyOnce = true;
        an.Play("shape");

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("hiddenBullet"))
        {
            if (player.powerup) {
                if (!onlyOnce2)
                {
                    Destroy(other.gameObject);
                    startMoving = true;
                    //bulletStrike = true;
                    onlyOnce2 = true;
                    manager mn = GameObject.FindObjectOfType(typeof(manager)) as manager;
                    mn.increaseScore();
                }
            }
                

        }
        
    }
}
