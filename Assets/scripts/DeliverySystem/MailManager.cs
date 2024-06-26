using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    public int quota;
    public int deliveries;
    public int currentAdress = -1;
    public float timer;

    public AudioSource success;
    public AudioSource failure;

    public TMP_Text quotaText;
    public Text timerText;
    public GameObject button;
    private bool performanceAdequate;

    public List<GameObject> houses;


    [Header("Delivery box")]

    [SerializeField] private deliveryChat deliverychat;

    [Header("Package generator")]
    generator_Package genPac;

    [Header("New inventory")]
    public GameObject Inventory;
    public GameObject packagePrefab;
    public List<GameObject> packages = new List<GameObject>();

    public string nextScene;
    public int fine;

    public void End()
    {
        if (timer <= 0)
        {
            if (performanceAdequate)
            {
                globalVariables.money += 140 * (globalVariables.day/2);
            }

            globalVariables.money += deliveries * 5 * globalVariables.day;
            globalVariables.money -= fine * globalVariables.day;
            performanceAdequate = false;
            //Loads the next scene. 
            SceneManager.LoadScene(nextScene);
        }
    }

    private void MeetQuota()
    {
        if (deliveries >= quota)
        {
            button.SetActive(true);
            performanceAdequate = true;
        }
    }

    public void Zero()
    {
        timer = 0;
    }

    private void Awake()
    {
        ui_package.enabled = true;

        deliverychat = GameObject.Find("Delivery_UI").GetComponent<deliveryChat>();
        genPac = gameObject.GetComponent<generator_Package>();
    }

    //tells the player object where it is
    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("deliveryPoint"))
    //     {
    //     Place = other.gameObject;
    //     house = Place.GetComponentInParent<House>();
    //     currentAdress = House.adress;
    //     Debug.Log("arriving at" + currentAdress);
    //     }
    // }


    //resets adress
    // public void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("deliveryPoint"))
    //     {
    //         Debug.Log("now leaving" + currentAdress);
    //         currentAdress = -1;
    //         Place = null;
    //         house = null;
    //     }
    // }

    // Start is called before the first frame update
    void Start()
    {
        ui_package.gameObject.SetActive(false);
        deliveries = 0;
        // currentAdress = -1;
        Inventory.SetActive(false);


        createAddresses();
        genPac.setPossibleAdresses(houses.Count - 1);
        setupPackages();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;
        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        timerText.text = timerString;
        quotaText.SetText("Quota: " + quota.ToString() + "\nDeliveries: " + deliveries.ToString());
        MeetQuota();
        End();

        if (deliverychat.inactivePackages >= quota)
        {
            setupPackages();
            deliverychat.inactivePackages = 0;
        }

        // if (Input.GetKeyDown(KeyCode.E) && house != null)
        // {
        //     deliverychat.StartDelivery(currentAdress);
        // }
    }

    void setupPackages()
    {
        Inventory = GameObject.Find("packageInventory");

        for (int i = 0; i < quota; i++)
        {
            GameObject pac = Instantiate(packagePrefab, Inventory.transform);
            string[] packInfo = genPac.Generate_Package(true);
            pac.GetComponent<package2>().setValues(packInfo);

            packages.Add(pac);
        }

        deliverychat.createUI(packages);

    }

    void morePackages()
    {
        for (int i = 0; i < quota; i++)
        {
            GameObject pac = Instantiate(packagePrefab, Inventory.transform);
            string[] packInfo = genPac.Generate_Package(true);
            pac.GetComponent<package2>().setValues(packInfo);

            packages.Add(pac);
        }

        deliverychat.createUI(packages);
    }

    void createAddresses()
    {
        var f = GameObject.Find("Buildings").transform.childCount;

        for (int i = 0; i < f; i++)
        {
            GameObject tempHouse = GameObject.Find("Buildings").transform.GetChild(i).gameObject;

            tempHouse.GetComponent<House>().setAdress(i);

            houses.Add(tempHouse);
        }
    }
}
