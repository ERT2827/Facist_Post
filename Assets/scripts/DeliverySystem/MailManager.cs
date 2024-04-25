using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
{
    [SerializeField]
    private Package package;
    [SerializeField]
    private House house;

    public Collider Player; 

    public Package Package { get => package; }
    public House House { get => house; }

    public int quota;
    public int deliveries;
    public int currentAdress;

    public GameObject[] shelfSlots = new GameObject[12];

    public void Deliver()
    {
        if (Package.deliveryAdress == currentAdress)
        {
            deliveries += 1;
            Package.Destroy(Package);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == House.houseCollider)
        {
            currentAdress = House.adress;
            Debug.Log("arriving at" + currentAdress);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider == House.houseCollider)
        {
            Debug.Log("now leaving" + currentAdress);
            currentAdress = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        deliveries = 0;
        currentAdress = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
