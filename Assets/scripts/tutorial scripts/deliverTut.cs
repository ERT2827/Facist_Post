using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deliverTut : MonoBehaviour
{
    void Update()
    {
       if(globalVariables.UI_Open){
        gameObject.SetActive(false);
       } 
    }
}
