using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private GameObject baller;
    [SerializeField] private float moveSpeed;
    Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        baller = gameObject.transform.GetChild(0).gameObject;
        rb = baller.GetComponent<Rigidbody>();

        baller.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        applyforce(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);

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
}
