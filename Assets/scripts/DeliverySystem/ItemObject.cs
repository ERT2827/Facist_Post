using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private Package package;
    public Package Package { get =>  package; }

    [SerializeField]
    private UI ui;
    public UI UI { get => ui; }

    private void Awake()
    {
        GameObject inventorybar = GameObject.Find("InventoryBar");
        ui = inventorybar.GetComponent<UI>();
    }


    public void OnTriggerEnter(Collider other)
    {
        PickupItem();
    }

    public void PickupItem()
    {
        UI.AddInventorySlot(Package);
        
    }
}
