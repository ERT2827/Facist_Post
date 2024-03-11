using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devisualizer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        // if(other.gameObject.layer != "Ground"){
        //     other.gameObject.GetComponent<Renderer>().material.color.a = 0.4f;
        // }
    }
}
