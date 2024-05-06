using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    public GameObject Place;
    [SerializeField]
    private House house;

    public House House { get => house; }

    public Collider Player;
    


    public GameObject[] houses;

    public int quota;
    public int deliveries;
    public int currentAdress = -1;

    public GameObject[] packages = new GameObject[12];


    //tells the player where they are
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == GameObject.FindGameObjectWithTag("house"))
        {
            Place = collision.gameObject;
            house = Place.GetComponent<House>();
            currentAdress = House.adress;
            Debug.Log("arriving at" + currentAdress);
        }
    }

    //resets adress
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider == GameObject.FindGameObjectWithTag("house"))
        {
            Debug.Log("now leaving" + currentAdress);
            currentAdress = -1;
            Place = null;
            house = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        deliveries = 0;
        currentAdress = -1;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
