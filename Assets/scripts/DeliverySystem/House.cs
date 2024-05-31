using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public int adress;
    public string houseName;
    public Collider houseCollider;

    deliveryChat delChat;

    //public Text houseText;

    // bool houseSelect = false;

    // Start is called before the first frame update
    void Start()
    {
        //houseText.text = houseName;

        delChat = GameObject.Find("Delivery_UI").GetComponent<deliveryChat>();
    }

    // Update is called once per frame
    void Update()
    {}

    private void OnMouseOver() {
        delChat.HouseDisplay(adress);
        
        if(Input.GetMouseButtonDown(0)){
            delChat.StartDelivery(adress);
        }
    }

    private void OnMouseExit() {
        delChat.HouseDisplay(-1);
    }

}
