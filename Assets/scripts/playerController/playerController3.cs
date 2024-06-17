using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController3 : MonoBehaviour //Or indeed, tokyo drift
{
    /* we're stripping back the player controller
    to make the primary challenge navigating facism
    rather than controlling this shit ass car. */

    [Header("Movement")]

    public float moveSpeed = 10;
    public int damage;

    Vector2 move;

    Vector3 lastLook = new Vector3(0, 0, 1);

    // [Header("Dodge")]
    // [SerializeField] private float dodgeSpeed;
    // [SerializeField] private float dodgeDuration;
    // bool dodging = false;
    // Vector3 dodgeDir;
    // bool coolin = false;
    // [SerializeField] private float coolinDuration;

    [Header("Offroad")]

    bool isOnRoad;

    bool gear = false;

    [SerializeField] private LayerMask groundLayers;

    /* Having different speeds for on and off road allows the two 
    gears to have more distinct roles from each other.*/
    [SerializeField] private int onRoadH;
    [SerializeField] private int offRoadH;

    [SerializeField] private int onRoadL;
    [SerializeField] private int offRoadL;

    GameObject gearUI;

    GameObject stick;
    GameObject pos1;
    GameObject pos2;

    public AudioSource engineAudio;
    public AudioSource anthemAudio;
    public bool isMoving;
    public Rigidbody playerRB;


    // Start is called before the first frame update
    void Start()
    {
        gearUI = GameObject.Find("Gear Indicator");

        stick = gearUI.transform.GetChild(1).gameObject;
        pos1 = gearUI.transform.GetChild(2).gameObject;
        pos2 = gearUI.transform.GetChild(3).gameObject;

        globalVariables.day++;
        if (globalVariables.day > 1)
        {
            anthemAudio.volume = 0.15f * (globalVariables.day - 1);
        }
    }



    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(globalVariables.UI_Open){
            gearUI.SetActive(false);
        }else if(Input.GetKeyDown(KeyCode.LeftShift)){

            Debug.Log("Shifting Gears");
            gear = !gear;

            if(gear){
                stick.transform.position = pos1.transform.position;
            }else{
                stick.transform.position = pos2.transform.position;
            }
        }

        EngineAudio();

        //Dodging code

        // if(dodging){
        //     transform.Translate(dodgeDir * dodgeSpeed * Time.deltaTime, Space.World);
        // }else if(Input.GetButton("Fire1") && move.magnitude > 0 && !coolin){
        //     StartCoroutine(dodgeFunct());
        //     Debug.Log("bleepus");
        // }
    }

    private void FixedUpdate() {
        checkTerrain();
        movePlayer();
        gearSpeed();
    }

    private void EngineAudio()
    {
        if (gear)
        {
            engineAudio.pitch = 0.5f;
        }else
        {
            engineAudio.pitch = 0.4f;
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            engineAudio.Play();
        }else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            engineAudio.Pause();
        }
    }

    void movePlayer(){
        // Add slowing on different terrain
        
        Vector3 movement = new Vector3(move.x, 0, move.y);

        if(movement.magnitude > 0){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            lastLook = movement;
        }else{
            transform.rotation = Quaternion.LookRotation(lastLook);
        }


        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }

    void checkTerrain(){
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, Mathf.Infinity, groundLayers)){
            if(hit.collider.gameObject.tag == "road"){
                isOnRoad = true;
                // Debug.Log(hit.collider.gameObject.name);
            }else{
                isOnRoad = false;
                // Debug.Log(hit.collider.gameObject.name);
            }
        }        

        // Debug.Log("Is on road? " + isOnRoad);

    }

    void gearSpeed(){
        if(gear){
            if(isOnRoad){
                moveSpeed = onRoadH;
            }else if(!isOnRoad){
                moveSpeed = offRoadH;
            }
        }else{
            if(isOnRoad){
                moveSpeed = onRoadL;
            }else if(!isOnRoad){
                moveSpeed = offRoadL;
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        damage++; 
    }

    // IEnumerator dodgeFunct(){
    //     dodging = true;
    //     dodgeDir = new Vector3(move.x, 0, move.y);

    //     yield return new WaitForSeconds(dodgeDuration);

    //     dodging = false;

    //     StartCoroutine(dodgeCooldown());
    // }

    // IEnumerator dodgeCooldown(){
    //     coolin = true;

    //     yield return new WaitForSeconds(coolinDuration);

    //     coolin = false;
    // }
}
