using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invButtonScript : MonoBehaviour
{
    Button thisButton;
    public package2 parentPackage;
    deliveryChat delChat;

    private void Start() {
        thisButton = gameObject.GetComponent<Button>();
        thisButton.onClick.AddListener(setActivePackage);

        delChat = GameObject.Find("Delivery_UI").GetComponent<deliveryChat>();
    }

    private void Update() {
        if(!parentPackage.active){
            gameObject.SetActive(false);
        }
    }

    public void setParentPackage(GameObject PP){
        parentPackage = PP.GetComponent<package2>();
        transform.GetChild(0).gameObject.GetComponent<Text>().text = "Package " + parentPackage.PIN.ToString();
    }

    void setActivePackage(){
        delChat.setCurrentInvPack(parentPackage);
    }


}
