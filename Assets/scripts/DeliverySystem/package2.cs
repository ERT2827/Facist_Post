using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package2 : MonoBehaviour
{
    public int adress = 0;
    public string info = "";
    public bool correct = true;
    public bool legal = false;
    public int durability = 0;

    public void setValues(string[] values){
        int.TryParse(values[0], out adress);
        info = values[1] + values[2];
        correct = bool.Parse(values[3]);
        legal = bool.Parse(values[4]);
        int.TryParse(values[5], out durability);
    }
}
