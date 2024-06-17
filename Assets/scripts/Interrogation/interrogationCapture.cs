using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interrogationCapture : MonoBehaviour
{
    [SerializeField] private GameObject intWindow;
    [SerializeField] private GameObject intController;
    [SerializeField] private IntMiniGame intMini;


    private void Awake()
    {
        intWindow = GameObject.Find("InterrogationWindow");
        intController = GameObject.Find("InterrogationController");
        intMini = intController.GetComponent<IntMiniGame>();
    }

    private void Start()
    {
        intWindow.SetActive(false);
        intController.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            intWindow.SetActive(true);
            intController.SetActive(true);

            // Interrogation start
            intController.GetComponent<IntMiniGame>().StartInterrogation();
        }
    }

    public void EndInterrogation(bool win)
    {
        intWindow.SetActive(false);
        intController.SetActive(false);

        if (!win)
        {

        }

    }
}
