using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    /* I decided to rework the player controller based
    on feedback from my mentees, and I'm using
    the controller for my honors game as the 
    basis for doing so. */
    
    [Header("Movement")]
    public float moveSpeed = 10;

    Vector2 move;

    [SerializeField] private GameObject baller;


    Vector3 lastLook = new Vector3(0, 0, 1);

    [SerializeField] private Rigidbody arbees; //Target Rigidbody
    [SerializeField] private Rigidbody rb; //Baller Rigidbody

    [SerializeField] private float followSpeedMult;
    [SerializeField] private float followSpeed;

    [SerializeField] private Collider targetCollider;


    [Header("Dodge")]
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeDuration;
    bool dodging = false;
    Vector3 dodgeDir;

    public GameObject MailManager;
    
    // Start is called before the first frame update
    void Start()
    {
        arbees = gameObject.GetComponent<Rigidbody>();

        baller = gameObject.transform.GetChild(0).gameObject;
        rb = baller.GetComponent<Rigidbody>();

        baller.transform.parent = null;

        targetCollider = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        arbees.velocity = new Vector3(0, arbees.velocity.y, 0);

        if(!dodging)
        {
            movePlayer();
        }

        //Dodging code

        if(dodging){
            transform.Translate(dodgeDir * dodgeSpeed * Time.deltaTime, Space.World);
        }else if(Input.GetButton("Fire1") && move.magnitude > 0){
            StartCoroutine(dodgeFunct());
            Debug.Log("bleepus");
        }

        //Code that moves the actual object
        BallMover();

        if (Input.GetButtonDown("Fire2"))
        {//shows and hides the inventory
            if (MailManager.activeSelf == true)
            {
                MailManager.SetActive(false);
            }
            else if (!MailManager.activeSelf)
            {
                MailManager.SetActive(true);
            }
        }

    }

    void movePlayer(){
        Vector3 movement = new Vector3(move.x, 0, move.y);

        if(movement.magnitude > 0){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            lastLook = movement;
        }else{
            transform.rotation = Quaternion.LookRotation(lastLook);
        }


        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }


    IEnumerator dodgeFunct(){
        dodging = true;
        dodgeDir = new Vector3(move.x, 0, move.y);

        yield return new WaitForSeconds(dodgeDuration);

        dodging = false;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.layer != 6){
            Physics.IgnoreCollision(targetCollider, other.collider);
        }
    }

    void BallMover(){
        followSpeed = Vector3.Distance(transform.position, baller.gameObject.transform.position) * followSpeedMult;

        baller.transform.LookAt(gameObject.transform);        

        if(Vector3.Distance(transform.position, baller.transform.position) < 0.8){
            baller.transform.position = Vector3.Lerp(transform.position, baller.transform.position, 4f);
            rb.velocity = new Vector3(0, 0, 0);
        }else{
            rb.AddRelativeForce(Vector3.forward * followSpeed, ForceMode.Force);
        }
    }
}
