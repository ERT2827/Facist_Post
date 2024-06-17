using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generator_Package : MonoBehaviour
{
    [SerializeField] int correctOdds = 50;
    [SerializeField] int maxDurability = 10;

    [SerializeField] string[] legalPackages;
    [SerializeField] string[] illegalPackages;

    [SerializeField] string[] names;
    [SerializeField] string date = "12-5-1938";
    [SerializeField] string ID = "111111111";

    MailManager mailManager;
    List<int> possibleAdresses = new List<int>();

    [SerializeField] private int wrongnessMult = 3;
    int wrongVals = 0;

    [Header("Wrong Bools")]
    bool nameBool = false;
    bool contentBool = false;
    bool dateBool = false;
    bool IDBool = false;
    bool addressBool = false;

    private void Awake() {
        mailManager = gameObject.GetComponent<MailManager>();

        Debug.Log(possibleAdresses.Count);
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
        string durability;

        // The difference between a package being correct and legal is that legality is something you simply have to learn (as opposed to finding by comparison), making it far more punishing (to reflect facist ideology of being pricks)
        // Illegal packages will never be in your quota, which is to somewhat offset the difficulty.
        // Delivering an illegal package also has a higher penalty than an incorrect one.

        int h = Random.Range(0, possibleAdresses.Count - 1);

        address = possibleAdresses[h].ToString();
        possibleAdresses.RemoveAt(h);

        reciever = names[Random.Range(0, names.Length - 1)];

        durability = Random.Range(0, maxDurability).ToString();

        ID = Random.Range(111111111, 999999999).ToString();

        int packCont = Random.Range(0, legalPackages.Length - 1);
        contents = legalPackages[packCont];    

        int isCor = Random.Range(0, 100);
        
        if(isCor < correctOdds){
            correct = "true";
        }else{
            correct = "false";
        }

        string[] packageInfo = {address, contents, reciever, date, correct, durability, ID};

        Debug.Log(packageInfo[0] + packageInfo[1] + packageInfo[2] + packageInfo[3] + packageInfo[4]);

        return packageInfo;
    }


    // This generates the contents of the package, 
    // which the player will have to monitor.

    public void setPossibleAdresses(int houses){
        for (int i = 0; i < houses; i++)
        {
            possibleAdresses.Add(i);
        }
    }

    public string Generate_Permit(package2 package){
        wrongVals = 0;

        nameBool = false;
        contentBool = false;
        dateBool = false;
        IDBool = false;
        addressBool = false;
        
        if(package.correct){
            return("Name: " + package.reciever + "\nContents: " + package.contents + "\nDate: " + package.date + "\n ID: " + package.ID);
        }else{
            string nameTemp;
            string contentTemp;
            string dateTemp;
            string IDTemp;
            
            int wrongTarget = (Random.Range(0, 10) * wrongnessMult) / 10;

            generate_Permit_WrongBools(wrongTarget);

            if(nameBool){
                nameTemp = names[Random.Range(0, names.Length - 1)];
            }else{
                nameTemp = package.reciever;
            }
            if(contentBool){
                contentTemp = legalPackages[Random.Range(0, legalPackages.Length - 1)];  
            }else{
                contentTemp = package.contents;
            }
            if(dateBool){
                dateTemp = "14-3-1932";
            }else{
                dateTemp = package.date;
            }
            if(IDBool){
                IDTemp = Random.Range(111111111, 999999999).ToString();;
            }else{
                IDTemp = package.ID.ToString();
            }

            return("Permit: \nName: " + nameTemp + "\nContents: " + contentTemp + "\nDate: " + dateTemp + "\n ID: " + IDTemp);

        }

    }

    void generate_Permit_WrongBools(int wrongT){        
        if(Random.Range(0, 100) > 50){
            nameBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if(Random.Range(0, 100) > 50){
            contentBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if(Random.Range(0, 100) > 50){
            dateBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if(Random.Range(0, 100) > 50){
            IDBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if (wrongVals < wrongT)
        {
            generate_Permit_WrongBools(wrongT);
        }
    }

    public string Generate_ID(package2 package){
        wrongVals = 0;

        nameBool = false;
        contentBool = false;
        dateBool = false;
        IDBool = false;
        addressBool = false;


        
        if(package.correct){
            return("ID: \nName: " + package.reciever + "\n ID: " + package.ID + "\nAddress: " + package.address);
        }else{
            string nameTemp;
            string addressTemp;
            string IDTemp;
            
            int wrongTarget = (Random.Range(0, 10) * wrongnessMult) / 10;

            generate_ID_WrongBools(wrongTarget);

            if(nameBool){
                nameTemp = names[Random.Range(0, names.Length - 1)];
            }else{
                nameTemp = package.reciever;
            }
            if(IDBool){
                IDTemp = Random.Range(111111111, 999999999).ToString();;
            }else{
                IDTemp = package.ID.ToString();
            }
            if(addressBool){
                addressTemp = Random.Range(0, mailManager.houses.Count -1).ToString();
            }else{
                addressTemp = package.address.ToString();
            }

            return("Name: " + nameTemp + "\n ID: " + IDTemp + "\n Address: " + addressTemp);

        }
    }

    void generate_ID_WrongBools(int wrongT){        
        if(Random.Range(0, 100) > 50){
            nameBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if(Random.Range(0, 100) > 50){
            addressBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if(Random.Range(0, 100) > 50){
            IDBool = true;
            wrongVals += 1;
            if(wrongVals >= wrongT){
                return;
            }
        }
        if (wrongVals < wrongT)
        {
            generate_ID_WrongBools(wrongT);
        }
    }

}
