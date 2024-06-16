using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public int adress = 0;
    public Collider houseCollider;

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

        houseCollider = gameObject.GetComponent<Collider>();
        houseObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {}

    private void OnMouseOver() {
        delChat.HouseDisplay(adress);

        Debug.Log("Piss");
        
        if(Input.GetMouseButtonDown(0)){
            delChat.StartDelivery(adress);
        }
    }

    private void OnMouseExit() {
        delChat.HouseDisplay(-1);
    }

    public void setAdress(int addy){
        adress = addy;

        transform.GetChild(transform.childCount -1).gameObject.GetComponent<signScript>().setDisplay(addy);
    }

}
