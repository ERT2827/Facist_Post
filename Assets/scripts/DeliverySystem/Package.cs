using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Package : MonoBehaviour
{
    public float timer;
    public int durability;
    public int deliveryAdress;

    public Text timerText;

    public Collider packageCollider;

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

        Expire();
    }

    public void Deliver()
    {
        
    }

    //player loses package if they take too long or take too much damage
    private void Expire()
    {
        if (timer <= 0 ||  durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
