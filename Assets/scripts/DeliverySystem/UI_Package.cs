using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Package : MonoBehaviour
{
    public Package Package; 


    public Text timerText;
    public Text adressText;
    public Slider duraSlider;
    //public Sprite icon;

    public void DeliverButton()
    {
        // Package.Deliver();
    }

    void Update()
    {
        timerText.text = "By: " + Package.timerText.text;
        adressText.text = Package.adressText.text;
        duraSlider.value = Package.durability;

        if (Package == null)
        {
            gameObject.SetActive(false);
        }
    }
}
