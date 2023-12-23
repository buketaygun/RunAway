using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(40 * Time.deltaTime, 0, 0);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.numofCoins += 1;
            Debug.Log(Player.numofCoins);
            Destroy(gameObject);
        }
    }
}
