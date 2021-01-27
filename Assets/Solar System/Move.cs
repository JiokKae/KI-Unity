using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float rotateSpeed;

    public Transform[] childTransform;
    public float[] childRevolveSpeed;
    void Start()
    {   
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
        for (int i = 0; i < childTransform.Length; i++)
        {
            childTransform[i].RotateAround(transform.position, Vector3.up, (-rotateSpeed + childRevolveSpeed[i]) * Time.deltaTime);
        }
    }
}
