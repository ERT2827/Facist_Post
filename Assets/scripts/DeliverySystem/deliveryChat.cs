using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliveryChat : MonoBehaviour
{
    [SerializeField] private GameObject packageScroll;
    [SerializeField] private GameObject packagePref;
    [SerializeField] private MailManager mailBoss;

    public GameObject deliveryWindow;

    private GameObject infoWindow;
    private Text currentAddy;

    private Text currentAddyHover;
    private GameObject currentAddyHoverGO;

    public int currentViewedAddress;

    // [[SerializeField] private GameObject[] packageButtons;]
    
    void Awake()
    {
        infoWindow =  GameObject.Find("InfoWindow");
        currentAddyHoverGO = GameObject.Find("hoverObject");
        currentAddyHover = currentAddyHoverGO.transform.GetChild(0).GetComponent<Text>();
        
        if(GameObject.Find("MailManager") != null){
            mailBoss = GameObject.Find("MailManager").GetComponent<MailManager>();
        
            // Creates the packages in the UI

            GameObject[] packages = mailBoss.packages;

            if(packages != null){
                foreach (var i in packages){
                    GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
                    // packageButtons.
                }
            }else{
                for (int i = 0; i < 8; i++)
                {
                    GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
                }
        }
        }else{
            for (int i = 0; i < 8; i++)
            {
                GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
            }
        }
        
        
        
    }

    private void Start() {
        deliveryWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            deliveryWindow.SetActive(false);
            infoWindow.SetActive(false);
        }

        if(currentViewedAddress >= 0 && currentAddyHover != null){
            currentAddyHoverGO.SetActive(true);
            currentAddyHover.text = " Current House: " + currentViewedAddress;
        }else{
            currentAddyHoverGO.SetActive(false);   
        }

    }

    public void StartDelivery(int cur_address){
        deliveryWindow.SetActive(true);
        currentAddy = GameObject.Find("currentHouseText").GetComponent<Text>();

        currentAddy.text = " Address: " + cur_address;

        /* You need to make the button deliver the package that's selected,
        and also make it so that the info window displays information about the panel.
        I'll add the minigames later */
    }

    public void HouseDisplay(int cur_address){
        currentViewedAddress = cur_address;
    }

    // Put in a custom cursor to make this more intuitive
}
