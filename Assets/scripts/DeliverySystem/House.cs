using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public int adress = 0;
    public GameObject houseObject;

    deliveryChat delChat;

    //public Text houseText;

    // bool houseSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        //houseText.text = houseName;

        if(GameObject.Find("Delivery_UI").GetComponent<deliveryChat>() != null){
            delChat = GameObject.Find("Delivery_UI").GetComponent<deliveryChat>();
        };

        houseObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {}

    private void OnMouseOver() {
        delChat.HouseDisplay(adress);

        // Debug.Log("Piss");
        
        if(Input.GetMouseButtonDown(0) && !globalVariables.UI_Open){
            checkDistance();
        }
    }

    private void OnMouseExit() {
        delChat.HouseDisplay(-1);
    }

    public void setAdress(int addy){
        adress = addy;

        transform.GetChild(transform.childCount -1).gameObject.GetComponent<signScript>().setDisplay(addy);
    }

    void checkDistance(){
        GameObject playR = GameObject.FindWithTag("Player");

        float distance = Vector3.Distance(transform.position, playR.transform.position);
        

        if(distance < 8){
            delChat.StartDelivery(adress);
        }
    }

}
