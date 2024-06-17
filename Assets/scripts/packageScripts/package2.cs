using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package2 : MonoBehaviour
{
    public int address = 0;
    public string info = "";
    public bool correct = true;
    public bool legal = false;
    public int PIN = 0000;
    public string contents = "";
    public string date = "";
    public string reciever = "";
    public int ID = 111111111;

    [Header("Active status")]
    public bool active = true;
    public int durability = 0;

    public void setValues(string[] values){
        int.TryParse(values[0], out address);
        correct = bool.Parse(values[4]);
        int.TryParse(values[5], out durability);
        int.TryParse(values[6], out ID);

        contents = values[1];
        date = values[3];
        reciever = values[2];

        info = "Address: " + address + "\nContents: " + contents + "\nReciever: " + reciever + "\nDate: " + date + "\nID: " + ID;

        

        PIN = Random.Range(0001, 9999);
    }

    public void takeDamage(){
        durability --;
        if(durability == 0){
            setinactive();
        }
    }

    public void setinactive(){
        active = false;
    }
}
