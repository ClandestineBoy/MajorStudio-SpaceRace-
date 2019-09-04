using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controller : MonoBehaviour
{
    public KeyCode up, down;
    public float spd;
    public Rigidbody2D rb;

    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        rb.velocity = Vector2.zero;
        if (Input.GetKey(up))
        {
            rb.velocity = new Vector2(0,spd);
        }
        if (Input.GetKey(down))
        {
            rb.velocity = new Vector2(0, -spd);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = startPos;
    }
}
