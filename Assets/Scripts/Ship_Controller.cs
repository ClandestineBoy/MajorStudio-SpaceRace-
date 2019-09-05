using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Controller : MonoBehaviour
{
    public GameObject gcObj;
    public Projectile_Spawner gc;

    public KeyCode up, down;
    public float spd;
    public Rigidbody2D rb;
    public GameObject score;
    private Score_Keep scoreObj;
    private bool dead;
    private float respawnCount;
    public float respawnCountMax;
    private Vector2 startPos;
    void Start()
    {
        gcObj = GameObject.FindGameObjectWithTag("GameController");
        gc = gcObj.GetComponent<Projectile_Spawner>();
        respawnCount = respawnCountMax;
        dead = false;
        scoreObj = score.GetComponent<Score_Keep>();
        startPos = transform.position;
    }
    void Update()
    {
        if (gc.gameOn)
        {
            rb.velocity = Vector2.zero;
            if (dead)
            {
                respawnCount -= 1;
                if (respawnCount <= 0)
                {
                    dead = false;
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                if (Input.GetKey(up))
                {
                    rb.velocity = new Vector2(0, spd);
                }
                if (Input.GetKey(down))
                {
                    rb.velocity = new Vector2(0, -spd);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scoreObj.score = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = startPos;
        if (collision.gameObject.tag == ("Finish"))
        {
            scoreObj.score += 1;
        }
        dead = true;
        respawnCount = respawnCountMax;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
