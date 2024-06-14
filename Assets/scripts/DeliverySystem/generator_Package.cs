using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator_Package : MonoBehaviour
{
    [SerializeField] int correctOdds = 50;
    [SerializeField] int legalOdds = 80;

    [SerializeField] int maxDurability = 10;

    [SerializeField] string[] legalPackages;
    [SerializeField] string[] illegalPackages;

    [SerializeField] string[] names;
    [SerializeField] string date = "12-5-1938";

    MailManager mailManager;

    private void Awake() {
        mailManager = gameObject.GetComponent<MailManager>();
    }



    
    
    // This function returns a package string when called.
    // The init gen variable prevents it from generating illegal
    // goods when being called during the initial generation stage
    public string[] Generate_Package(bool initGen){
        string address; //The integer address the package should be delivered to
        string contents; //The contents of the package
        string reciever; //The person the package is being delivered to
        // string notes; I'm not planning on implementing this right now because I can't figure out how to make it satisfying.
        string correct; //The bool which determines whether the package is correct
        string legal; //The bool that determines whether the package is legal
        string durability;

        // The difference between a package being correct and legal is that legality is something you simply have to learn (as opposed to finding by comparison), making it far more punishing (to reflect facist ideology of being pricks)
        // Illegal packages will never be in your quota, which is to somewhat offset the difficulty.
        // Delivering an illegal package also has a higher penalty than an incorrect one.

        address = Random.Range(0, mailManager.houses.Length - 1).ToString();
        reciever = names[Random.Range(0, names.Length - 1)];

        durability = Random.Range(0, maxDurability).ToString();


        int isCor = Random.Range(0, 100);
        int isLegal = Random.Range(0, 100);
        
        if(isCor < correctOdds){
            correct = "true";
            legal = "true";
            contents = Generate_Contents(true);
        }else if(isLegal < legalOdds && !initGen){ //The initgen stop illegal packages from being distributed at the mail hub.
            correct = "true";
            legal = "false";
            contents = Generate_Contents(false);
        }else{
            correct = "false";
            legal = "true";
            contents = Generate_Contents(true);
        }

        string[] packageInfo = {address, contents, reciever, date, correct, legal, durability};

        Debug.Log(packageInfo[0] + packageInfo[1] + packageInfo[2] + packageInfo[3] + packageInfo[4]);

        return packageInfo;
    }

    // This generates the contents of the package, 
    // which the player will have to monitor.
    string Generate_Contents(bool isLegal){
        if(isLegal){
            int packCont = Random.Range(0, legalPackages.Length - 1);
            return(legalPackages[packCont]);
        }else{
            int packCont = Random.Range(0, illegalPackages.Length - 1);
            return(illegalPackages[packCont]);
        }
    }

    // public 

}
