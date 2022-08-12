using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject player;
    public float followSmoothness;

    PlayerMovement playerMovement;
    Rigidbody2D rb;
    public Vector3 followTransform;
    public bool followPlayer;

    void Start()
    {
        followPlayer = true;
        playerMovement = player.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(followPlayer == true){
            followTransform = player.transform.position;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(Vector2.Lerp(new Vector2(transform.position.x, transform.position.y), new Vector2(followTransform.x, followTransform.y), followSmoothness));
    }
}
