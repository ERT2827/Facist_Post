using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MailManager : MonoBehaviour
{
    public GameObject Place;
    [SerializeField]
    private House house;
    [SerializeField]
    private UI_Package ui_package;
    [SerializeField]
    private MenuManager menuManager;

    public House House { get => house; }
    public UI_Package UI_Package { get => ui_package; }
    public MenuManager MenuManager { get => menuManager; }

    public Collider player;

    public GameObject Inventory;

    public int quota;
    public int deliveries;
    public int currentAdress = -1;
    public float timer;

    public AudioSource success;
    public AudioSource failure;

    public Text quotaText;
    public Text timerText;
    public GameObject button;

    public GameObject[] houses;

    public GameObject[] packages = new GameObject[12];



    public void End()
    {
        if (timer <= 0)
        {
            if (quota < deliveries)
            {
                MenuManager.ResetGame();
            }else if (quota >= deliveries)
            {
                MenuManager.LoadScene("Win");
            }
        }
    }

    private void MeetQuota()
    {
        if (quota <= deliveries)
        {
            button.SetActive(true);
        }
    }

    public void Zero()
    {
        timer = 0;
    }

    private void Awake()
    {
        ui_package.enabled = true;
    }

    //tells the player object where it is
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("deliveryPoint"))
        {
            Place = other.gameObject;
            house = Place.GetComponentInParent<House>();
            currentAdress = House.adress;
            Debug.Log("arriving at" + currentAdress);
        }
    }
    

    //resets adress
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("deliveryPoint"))
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
        ui_package.gameObject.SetActive(false);
        deliveries = 0;
        currentAdress = -1;
        Inventory.SetActive(false);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;
        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        timerText.text = timerString;
        quotaText.text = "Quota: " + deliveries.ToString() + "/" + quota.ToString();
        MeetQuota();
        End();
    }
}
