using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{

    void OnMouseDrag()
    {

        float roty = Input.GetAxis("Mouse X") * 4 * Mathf.Deg2Rad;
        float rotx = Input.GetAxis("Mouse Y") * 4 * Mathf.Deg2Rad;
        transform.RotateAround(Vector3.up, -roty);
        transform.RotateAround(Vector3.left, -rotx);


    }
}