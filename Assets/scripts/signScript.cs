using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signScript : MonoBehaviour
{
    [SerializeField] private Text signText;
    
    private void Start() {
        setDisplay(0);
        // signText = game  Object.transform.GetChild(1).GetChild(0).GetComponent<Text>();
    }
    
    public void setDisplay(int addy){
        Debug.Log("Bingus");
        transform.rotation = Quaternion.Euler(0, 0, 0);
        signText.text = addy.ToString();    
    }
}
