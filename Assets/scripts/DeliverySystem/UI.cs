using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject m_slotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //InventorySystem.current.onInventoryChangedEvent += OnUpdateInventory;
    }

    private void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        //DrawInventory();
    }



    public void AddInventorySlot(Package item)
    {
        GameObject obj = Instantiate(m_slotPrefab);
        obj.transform.SetParent(transform, false);

        Slot slot = obj.GetComponent<Slot>();
        //slot.Set(item);
    }

    private void Update()
    {
        Slot slot = GetComponent<Slot>();
        
    }
}
