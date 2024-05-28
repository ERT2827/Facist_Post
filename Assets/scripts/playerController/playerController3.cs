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

    Vector2 move;

    Vector3 lastLook = new Vector3(0, 0, 1);

    [Header("Dodge")]
    [SerializeField] private float dodgeSpeed;
    [SerializeField] private float dodgeDuration;
    bool dodging = false;
    Vector3 dodgeDir;
    bool coolin = false;
    [SerializeField] private float coolinDuration;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Dodging code

        if(dodging){
            transform.Translate(dodgeDir * dodgeSpeed * Time.deltaTime, Space.World);
        }else if(Input.GetButton("Fire1") && move.magnitude > 0 && !coolin){
            StartCoroutine(dodgeFunct());
            Debug.Log("bleepus");
        }
    }

    private void FixedUpdate() {
        if(!dodging)
        {
            movePlayer();
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

    IEnumerator dodgeFunct(){
        dodging = true;
        dodgeDir = new Vector3(move.x, 0, move.y);

        yield return new WaitForSeconds(dodgeDuration);

        dodging = false;

        StartCoroutine(dodgeCooldown());
    }

    IEnumerator dodgeCooldown(){
        coolin = true;

        yield return new WaitForSeconds(coolinDuration);

        coolin = false;
    }
}
