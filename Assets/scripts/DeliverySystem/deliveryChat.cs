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

    public package2 currentPackage;
    public int currentViewedAddress;
    public int previewAddress;

    [SerializeField] private generator_Package genPack;

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
    [SerializeField] List<int> visitedHousesID = new List<int>();
    [SerializeField] List<int> visitedHousesPermit = new List<int>();

    [Header("Day specific variables")]
    [SerializeField] private bool day1;

    [Header("Inventory")]
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private GameObject invInfoWindow;
    [SerializeField] private TMP_Text invInfoWindowText;
    [SerializeField] private GameObject invPref;
    [SerializeField] private Transform inventoryScroll;
    public package2 currentInvPackage;
    
    void Awake()
    {
        infoWindow =  GameObject.Find("InfoWindow");
        infoWindowText = infoWindow.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();

        currentAddyHoverGO = GameObject.Find("hoverObject");
        currentAddyHover = currentAddyHoverGO.transform.GetChild(0).GetComponent<Text>();

        ID_WindowText = ID_Window.transform.GetChild(0).GetComponent<TMP_Text>();

        Permit_WindowText = Permit_Window.transform.GetChild(0).GetComponent<TMP_Text>();

        mailBoss = GameObject.Find("MailManager").GetComponent<MailManager>();
        
        
    }

    private void Start() {
        deliveryWindow.SetActive(false);
        inventoryWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && globalVariables.UI_Open){
            closeDeliveryUI();
            closeInventoryUI();
        }

        if(Input.GetMouseButtonDown(1) && !globalVariables.UI_Open){
            openInventory();
        }

        if(previewAddress >= 0 && currentAddyHover != null && !globalVariables.UI_Open){
            currentAddyHoverGO.SetActive(true);
            currentAddyHover.text = " Current House: " + previewAddress;
        }else{
            currentAddyHoverGO.SetActive(false);   
        }

    }

    public void StartDelivery(int cur_address){
        currentViewedAddress = cur_address;
        deliveryWindow.SetActive(true);
        currentAddy = GameObject.Find("currentHouseText").GetComponent<Text>();

        globalVariables.UI_Open = true;

        currentAddy.text = " Address: " + cur_address;

        /* You need to make the button deliver the package that's selected,
        and also make it so that the info window displays information about the panel.
        I'll add the minigames later */
    }

    public void openInventory(){
        inventoryWindow.SetActive(true);
        globalVariables.UI_Open = true;
    }

    public void HouseDisplay(int cur_address){
        previewAddress = cur_address;
    }

    // Put in a custom cursor to make this more intuitive

    public void setCurrentPack(package2 PackedUp){
        currentPackage = PackedUp;
        infoWindow.SetActive(true);

        if(PackedUp.info != null){
            infoWindowText.SetText(PackedUp.info);
        }
    }
    public void setCurrentInvPack(package2 PackedUp){
        currentInvPackage = PackedUp;
        invInfoWindow.SetActive(true);

        if(PackedUp.info != null){
            Debug.Log("edgar");
            invInfoWindowText.SetText(PackedUp.info);
        }
    }

    public void openInfo(){
        
    }

    public void openPermitWindow(){
        Debug.Log(currentViewedAddress);
        Debug.Log(currentPackage.address);
        
        if(currentPackage == null){
            permit_Text = "No package selected!";
        }else if(currentViewedAddress != currentPackage.address){
            permit_Text = "Wrong house, sorry";
        }else if(!visitedHousesPermit.Contains(currentViewedAddress)){
            visitedHousesPermit.Add(currentViewedAddress);
            string temp = genPack.Generate_Permit(currentPackage);
            permit_Text = temp;
            permit_Texts.Add(temp);
        }else{
            Debug.Log("Repeat customer");
            int i = visitedHousesPermit.IndexOf(currentViewedAddress);
            permit_Text = permit_Texts[i];
        }

        Permit_Window.SetActive(true);
        ID_Window.SetActive(false);
        Permit_WindowText.SetText(permit_Text);


    }
    
    public void openIDWindow(){
        if(currentPackage == null){
            ID_Text = "No package selected!";
        }else if(currentViewedAddress != currentPackage.address){
            ID_Text = "Wrong house, sorry";
        }else if(!visitedHousesID.Contains(currentViewedAddress)){
            visitedHousesID.Add(currentViewedAddress);
            string temp = genPack.Generate_ID(currentPackage);
            Debug.Log(temp);
            
            ID_Text = temp;
            ID_Texts.Add(temp);
        }else{

            Debug.Log("Repeat customer");
            int i = visitedHousesID.IndexOf(currentViewedAddress);
            ID_Text = ID_Texts[i];
        }

        Permit_Window.SetActive(false);
        ID_Window.SetActive(true);
        ID_WindowText.SetText(permit_Text);
    }

    public void closeDeliveryUI(){
        Permit_Window.SetActive(false);
        ID_Window.SetActive(false);
        deliveryWindow.SetActive(false);
        infoWindow.SetActive(false);

        Permit_WindowText.SetText("");
        ID_WindowText.SetText("");

        globalVariables.UI_Open = false;
    }
    
    public void closeInventoryUI(){
        inventoryWindow.SetActive(false);
        invInfoWindow.SetActive(false);

        globalVariables.UI_Open = false;
    }

    public void createUI(List<GameObject> packs){
        if(GameObject.Find("MailManager") != null){
        
            // Creates the packages in the UI

            if(packs != null){
                Debug.Log(packs.Count);
                
                for (int i = 0; i < packs.Count; i++)
                {
                    GameObject myNewPackage = Instantiate(packagePref, packageScroll.transform);
                    myNewPackage.GetComponent<packageButtonScript>().setParentPackage(packs[i]);

                    GameObject myNewInvPackage = Instantiate(invPref, inventoryScroll);
                    myNewInvPackage.GetComponent<invButtonScript>().setParentPackage(packs[i]);
                }
            }else{
                // Debug.Log("Shit");
            }
        }
    }

    public void deliver(){
        if(day1 && currentViewedAddress == currentPackage.address){
            mailBoss.deliveries += 1;
            currentPackage.setinactive();
            Debug.Log(mailBoss.deliveries);
        }else if(currentViewedAddress == currentPackage.address && currentPackage.correct && currentPackage.legal){
            mailBoss.deliveries += 1;
            currentPackage.setinactive();
            Debug.Log("Hooray");
        }else{
            currentPackage.setinactive();
            Debug.Log("Gulag");
        }
        
        
    }

   
}
