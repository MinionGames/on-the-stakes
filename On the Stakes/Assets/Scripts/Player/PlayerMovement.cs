using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    private GameObject leftLeg;
    [SerializeField]
    private GameObject rightLeg;
    private Rigidbody2D leftLegRB;
    private Rigidbody2D rightLegRB;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private float stepWait = 0.5f;

    [SerializeField]
    private float jumpForce = 10;
    private bool isOnGround;
    [SerializeField]
    private float positionRadius;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private Transform playerPos;
    

    void Start()
    {
        leftLegRB = leftLeg.GetComponent<Rigidbody2D>();
        rightLegRB = rightLeg.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0){
            if(Input.GetAxisRaw("Horizontal") > 0){
                anim.Play("Walk_Right");
                StartCoroutine(MoveRight(stepWait));
            }
            else{
                anim.Play("Walk_Left");
                StartCoroutine(MoveLeft(stepWait));
            }
        }
        else{
            anim.Play("Idle");
        }

        isOnGround = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        if(isOnGround && Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    IEnumerator MoveRight(float seconds){
        leftLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.right * (speed * 1000) * Time.deltaTime);
    }

    IEnumerator MoveLeft(float seconds){
        leftLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
        yield return new WaitForSeconds(seconds);
        rightLegRB.AddForce(Vector2.left * (speed * 1000) * Time.deltaTime);
    }

}
