using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryTut : MonoBehaviour
{
    void Update()
    {
       if(Input.GetMouseButtonDown(1)){
        gameObject.SetActive(false);
       } 
    }
}
