using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    [SerializeField]
    private MailManager mailManager;
    [SerializeField]
    private UI_Package ui_package;
    [SerializeField]
    private House house;

    public MailManager Manager { get => mailManager; }
    public UI_Package UI_Package { get => ui_package; }
    public House House {  get => house; }

    public float timer;
    public int durability;
    public int maxDura;
    public int deliveryAdress;
    public GameObject adress;
    

    public Text timerText;
    public Text adressText;
    public Slider duraSlider;
    public GameObject Button;


    private void Awake()
    {
        GameObject manager = GameObject.Find("MailManager");
        mailManager = manager.GetComponent<MailManager>();
        GameObject ui = GameObject.Find("PackageDisplay");
        ui_package = ui.GetComponent<UI_Package>();
        GenPac();
    }

    public void Deliver()
    {
        if (deliveryAdress == Manager.currentAdress)
        {
            Manager.success.Play();
            Debug.Log("delivered");
            Manager.deliveries += 1;
            Destroy(gameObject);
        }
        else
        {
            Manager.failure.Play();
            Debug.Log("wrong place");
        }
    }





    //generates package details randomly
    private void GenPac()
    {
        timer = Random.Range(60f, 600f);
        durability = Random.Range(2, 10);
        maxDura = durability;
        duraSlider.maxValue = maxDura;
        deliveryAdress = Random.Range(0, Manager.houses.Length);
        adress = Manager.houses[deliveryAdress];
        house = adress.GetComponent<House>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;
        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        timerText.text = timerString;
        adressText.text = "Deliver to: " + House.houseName;
        duraSlider.value = durability;

        Expire();
    }

    public void Select()
    {
        UI_Package.Package = this;
        UI_Package.duraSlider.maxValue = maxDura;
        ui_package.gameObject.SetActive(true);
    }

    //player loses package if they take too long or take too much damage
    private void Expire()
    {
        if (timer <= 0 || durability <= 0)
        {
            Destroy(gameObject);
            Debug.Log("gone");
        }
    }

    public void Toggle()
    {
        if (Button.activeSelf)
        {
            Button.SetActive(false);
        }else if (!Button.activeSelf)
        {
            Button.SetActive(true);
        }
    }
}
