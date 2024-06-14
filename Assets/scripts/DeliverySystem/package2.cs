using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package2 : MonoBehaviour
{
    public int address = 0;
    public string info = "";
    public bool correct = true;
    public bool legal = false;

    [Header("Active status")]
    public bool active = true;
    public int durability = 0;

    public void setValues(string[] values){
        int.TryParse(values[0], out address);
        correct = bool.Parse(values[4]);
        legal = bool.Parse(values[5]);
        int.TryParse(values[6], out durability);

        info = "Address: " + address + "\nContents: " + values[1] + "\nReciever: " + values[2] + "\nDate: " + values[3];
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
