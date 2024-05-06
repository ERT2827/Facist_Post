using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    [SerializeField]
    private MailManager mailManager;

    public MailManager Manager { get => mailManager; }

    public float timer;
    public int durability;
    public int deliveryAdress;
    public GameObject adress;
    

    public Text timerText;
    public Text adressText;
    public Slider duraSlider;
    public GameObject Button;

    
    public void Deliver()
    {
        if (deliveryAdress == Manager.currentAdress)
        {
            Manager.success.Play();
            Manager.deliveries += 1;
            gameObject.SetActive(false);
        }
        else
        {
            Manager.failure.Play();
            Debug.Log("wrong place");
        }
    }

    //generates package details randomly
    private void Awake()
    {
        GenPac();
    }

    private void OnEnable()
    {
        GenPac();
    }

    private void GenPac()
    {
        timer = Random.Range(60f, 600f);
        durability = Random.Range(2, 10);
        duraSlider.maxValue = durability;
        deliveryAdress = Random.Range(0, Manager.houses.Length);
        adress = Manager.houses[deliveryAdress];
    }

    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;
        int hours = (int)(timer / 3600) % 24;
        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        timerText.text = timerString;
        adressText.text = adress.ToString();
        duraSlider.value = durability;

        Expire();
    }



    //player loses package if they take too long or take too much damage
    private void Expire()
    {
        if (timer <= 0 ||  durability <= 0)
        {
            gameObject.SetActive(false);
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
