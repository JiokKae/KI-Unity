using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;
    public float pivot;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(target)
		{
            targetOffset = new Vector3(1f, 0f, 1f) * target.lossyScale.x;
            pivot = 1f * target.lossyScale.x;
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, 10f * Time.deltaTime);
            if(Vector3.Distance(transform.position, target.position) <= targetOffset.magnitude)
			{
                transform.position = target.position + targetOffset;
            }
            transform.forward = Vector3.Normalize(target.position - transform.position);
		}
    }
}
