using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform targetPrefabs;
    public Vector3 distance;
    void Start()
    {
        distance = transform.position - targetPrefabs.position;
    }

    
    void LateUpdate()
    {
        Vector3 finalPos = new Vector3(transform.position.x, transform.position.y, distance.z + targetPrefabs.position.z);
        transform.position = finalPos;
    }
}
