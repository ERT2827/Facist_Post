using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package_Button : MonoBehaviour
{
    
    private deliveryChat delChat;

    private string[] infoArray;


    private void Awake() {
        delChat =  GameObject.Find("Delivery Window").GetComponent<deliveryChat>();
    }

    public void getInfo(string[] a){
        infoArray = a;
    }

    public void openPackageInfo(){
        delChat.openInfo();
    }
}
