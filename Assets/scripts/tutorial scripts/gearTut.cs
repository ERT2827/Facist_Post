using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gearTut : MonoBehaviour
{
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftShift)){
        gameObject.SetActive(false);
       } 
    }
}
