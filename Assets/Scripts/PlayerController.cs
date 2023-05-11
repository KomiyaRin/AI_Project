using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(xMove, rb.velocity.y, zMove) * speed;
    }
}
