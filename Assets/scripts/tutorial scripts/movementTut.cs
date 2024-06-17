using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementTut : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Horizontal") != 0){
        gameObject.SetActive(false);
       } 
    }
}
