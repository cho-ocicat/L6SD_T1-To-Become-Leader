using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_move : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 8f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    //for counting death
    [SerializeField] TextMeshProUGUI hitCountText;
    int hitCount = 0;

    [SerializeField] AudioSource jumpSfx;
    [SerializeField] AudioSource deathSfx;
    [SerializeField] AudioSource respawnSfx;

    Vector3 respawnPoint;
    [SerializeField] Vector3 testResult;
    public GameObject fallDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horzInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horzInput * moveSpeed, rb.velocity.y, vertInput * moveSpeed);
        
        if(Input.GetButtonDown("Jump") && IsGrounded()){
            rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
            jumpSfx.Play();
        }

        if(Input.GetKey(KeyCode.Tab))
        {
            transform.position = testResult;
        }
    }

    //to limit jump movement
    bool IsGrounded()
    {
        //3 arguments: the position of the groundCheck object, the size of the sphere, layer mask
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            deathSfx.Play();
            hitCount++;
            hitCountText.text = "Hit: " + hitCount;
        }
        else if(other.tag == "Respawn")
        {
            respawnPoint = transform.position;
            respawnSfx.Play();
        }
    }
}
