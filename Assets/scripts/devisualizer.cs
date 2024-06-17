using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devisualizer : MonoBehaviour
{
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.layer == 7 && transform.position.z > other.transform.position.z){
            Color col = other.gameObject.GetComponent<Renderer>().material.color;


            col.a = 0.25f;

            other.gameObject.GetComponent<Renderer>().material.color = col;

        }else if(other.gameObject.transform.childCount > 1 && transform.position.z > other.transform.position.z){
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                if(other.gameObject.transform.GetChild(i).GetComponent<Renderer>() == null){
                    return;
                }
                
                Color col = other.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color;


                col.a = 0.25f;

                other.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = col;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.layer == 7){
            Color col = other.gameObject.GetComponent<Renderer>().material.color;


            col.a = 1f;

            other.gameObject.GetComponent<Renderer>().material.color = col;
            // Debug.Log(other.name);

        }else if(other.gameObject.transform.childCount > 1){
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                if(other.gameObject.transform.GetChild(i).GetComponent<Renderer>() == null){
                    return;
                }
                
                Color col = other.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color;


                col.a = 1f;

                other.gameObject.transform.GetChild(i).GetComponent<Renderer>().material.color = col;
            }
        }
    }
    
}
