using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mapEdge : MonoBehaviour
{
    [SerializeField] bool punishType;
    [SerializeField] TMP_Text punishWarning;

    private void OnTriggerExit(Collider other) {
        if (punishType){
            SceneManager.LoadScene("failScreen", LoadSceneMode.Single);
        }else{
            punishWarning.SetText("Desertion is Treason!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!punishType)
        {
            punishWarning.SetText("");
        }
    }
}
