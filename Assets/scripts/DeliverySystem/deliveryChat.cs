using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class deliveryChat : MonoBehaviour
{
    [SerializeField] private GameObject packageScroll;
    [SerializeField] private GameObject packagePref;
    [SerializeField] private MailManager mailBoss;

    public int currentPackage;
    public int currentViewedAddress;

    [Header("info windows")]
    
    public GameObject deliveryWindow;

    public GameObject infoWindow; //These two control the info window on the right
    TMP_Text infoWindowText;
    
    private Text currentAddy;
    private Text currentAddyHover;
    private GameObject currentAddyHoverGO;

    [SerializeField] GameObject ID_Window;
    private TMP_Text ID_WindowText;
    [SerializeField] GameObject Permit_Window;
    private TMP_Text Permit_WindowText;

    // [[SerializeField] private GameObject[] packageButtons;]

    [Header("Test Variables")]
    public string[] testStrings;
    public bool[] testCorrects;

    [Header("Comparison text")]

    string ID_Text;
    string permit_Text;

    List<string> ID_Texts = new List<string>();
    List<string> permit_Texts = new List<string>();

    [Header("Housechecks")]
    [SerializeField] List<int> visitedHouses = new List<int>();
    
    void Awake()
    {
        infoWindow =  GameObject.Find("InfoWindow");
        infoWindowText = infoWindow.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        currentAddyHoverGO = GameObject.Find("hoverObject");
        currentAddyHover = currentAddyHoverGO.transform.GetChild(0).GetComponent<Text>();

        ID_WindowText = ID_Window.transform.GetChild(0).GetComponent<TMP_Text>();

        Permit_WindowText = Permit_Window.transform.GetChild(0).GetComponent<TMP_Text>();
        
        // if(GameObject.Find("MailManager") != null){
        //     mailBoss = GameObject.Find("MailManager").GetComponent<MailManager>();
        
        //     // Creates the packages in the UI

        //     GameObject[] packages = mailBoss.packages*/;

        //     if(packages != null){
        //         for (int i = 0; i < packages.Length; i++)
        //         {
        //             GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
        //             myNewPackage.GetComponent<packageButtonScript>().setPackageNumber(i);
        //         }
        //     }else{
        //         for (int i = 0; i < testCorrects.Length; i++)
        //         {
        //             GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
        //             myNewPackage.GetComponent<packageButtonScript>().setPackageNumber(i);
        //         }
        // }
        // }else{
            for (int i = 0; i < testStrings.Length; i++)
            {
                GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
                myNewPackage.GetComponent<packageButtonScript>().setPackageNumber(i);
            }
        //}
        
        
        
    }

    private void Start() {
        deliveryWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            closeDeliveryUI();
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

    public void setCurrentPack(int PN){
        currentPackage = PN;

        infoWindowText.SetText(testStrings[PN]);
    }

    public void openInfo(){
        
    }

    public void openPermitWindow(){
        if(!visitedHouses.Contains(currentViewedAddress)){
            visitedHouses.Add(currentViewedAddress);
            string temp = "bogos binted";//genPack.generatePermit(isPackageAddress, packageDetails);
            permit_Text = temp;
            permit_Texts.Add(temp);
        }else{

            Debug.Log("Repeat customer");
            int i = visitedHouses.IndexOf(currentViewedAddress);
            permit_Text = permit_Texts[i];
        }

        Permit_Window.SetActive(true);
        ID_Window.SetActive(false);
        Permit_WindowText.SetText(permit_Text);


    }
    
    public void openIDWindow(){

    }

    public void closeDeliveryUI(){
        Permit_Window.SetActive(false);
        ID_Window.SetActive(false);
        deliveryWindow.SetActive(false);
        infoWindow.SetActive(false);

        Permit_WindowText.SetText("");
        ID_WindowText.SetText("");
    }
}
