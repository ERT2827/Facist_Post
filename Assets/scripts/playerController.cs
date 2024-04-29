using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [Header("Player settings")]
    
    [SerializeField] private GameObject baller;
    [SerializeField] private float moveSpeed;
    Rigidbody rb;

    [Header("Boost Settings")]

    [SerializeField] private float boostSpeed;
    [SerializeField] private float boostCoolDown;

    [SerializeField] private float boostPercent;
    [SerializeField] private float boostDuration;

    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        baller = gameObject.transform.GetChild(0).gameObject;
        rb = baller.GetComponent<Rigidbody>();

        baller.transform.parent = null;

        boostPercent = (100 + boostPercent) / 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        applyforce(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);

        // boost function
        if(Time.time >= timer && Input.GetKeyDown(KeyCode.LeftShift)){
            StartCoroutine(boost());
            timer = Time.time + boostCoolDown;
        }

        if(Input.GetButtonDown("Jump")){
            handbreak();
        }else if(Input.GetButtonUp("Jump")){
            rb.drag = 0.1f;
        }

        transform.position = baller.transform.position;

    }


    void applyforce(float dirX, float dirZ){
        rb.AddForce(dirX, 0, dirZ);
    }

    void handbreak(){
        rb.drag = 1;
    }

    IEnumerator boost(){
        moveSpeed = moveSpeed * boostSpeed;

        Debug.Log("Boosting");

        yield return new WaitForSeconds(boostDuration);

        moveSpeed = moveSpeed / boostSpeed;
    }
}
