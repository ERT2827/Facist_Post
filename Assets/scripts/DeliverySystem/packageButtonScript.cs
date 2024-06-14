using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class packageButtonScript : MonoBehaviour
{
    Button thisButton;
    public int packageNumber;
    deliveryChat delChat;

    private void Start() {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(setActivePackage);

        delChat = GameObject.Find("Delivery_UI").GetComponent<deliveryChat>();

        transform.GetChild(0).gameObject.GetComponent<Text>().text = "Package " + packageNumber.ToString();
    }

    public void setPackageNumber(int PN){
        packageNumber = PN;
    }

    void setActivePackage(){
        delChat.setCurrentPack(packageNumber);
    }


}
