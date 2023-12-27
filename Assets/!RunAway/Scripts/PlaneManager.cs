using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{
    public GameObject[] planeArray;
    public float zPlane = 0;
    public float yPlane = 0f;
    public int planeLength = 20;
    public int planeNum = 1;
    public Transform targetPlayer;
    public List<GameObject> activePlaneList;
    

    void Start()
    {
        activePlaneList = new List<GameObject>();
       

    

        for (int i = 0; i < planeNum; i++)
        {
            AddPlane(Random.Range(0, planeArray.Length));
        }
    }
      
 

    void Update()
    {
        if (targetPlayer.position.z -60> zPlane - (planeNum * planeLength))
        {
            AddPlane(Random.Range(0, planeArray.Length));
            RemovePlane();

        }

    }

    public void AddPlane(int idx)
    {
        GameObject plane = Instantiate(planeArray[idx], transform.forward * zPlane, transform.rotation);
        activePlaneList.Add(plane);
        zPlane += planeLength;
    }


    public void RemovePlane()
    {
       
        Destroy(activePlaneList[0],4f);
        activePlaneList.RemoveAt(0);
    }
   
}