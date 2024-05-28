using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    public int adress;
    public string houseName;
    public Collider houseCollider;

    //public Text houseText;

    // Start is called before the first frame update
    void Start()
    {
        //houseText.text = houseName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() {
        Debug.Log(houseName);
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(0)){
            GameObject mailChatUI = GameObject.Find("Delivery_UI").transform.GetChild(0).gameObject;
            Debug.Log("Bingo" + mailChatUI);
            mailChatUI.SetActive(true);
        }
    }
}
