using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devisualizer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != 6){
            Color col = other.gameObject.GetComponent<Renderer>().material.color;


            col.a = 0.1f;

            other.gameObject.GetComponent<Renderer>().material.color = col;

        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer != 6){
            Color col = other.gameObject.GetComponent<Renderer>().material.color;


            col.a = 1f;

            other.gameObject.GetComponent<Renderer>().material.color = col;
                    Debug.Log(other.name);

        }
    }
    
}
