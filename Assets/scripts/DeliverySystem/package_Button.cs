using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package_Button : MonoBehaviour
{
    
    private GameObject infoWindow;


    private void Awake() {
        infoWindow =  GameObject.Find("InfoWindow");
    }

    private void Start() {
        if (infoWindow != null) {
            infoWindow.SetActive(false);
        }
    }


    public void openPackageInfo(){
        infoWindow.SetActive(true);
    }
}
