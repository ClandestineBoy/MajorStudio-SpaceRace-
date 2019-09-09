using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ship_Controller : MonoBehaviour
{
    //Game Controller
    public GameObject gcObj;
    public Projectile_Spawner gc;
    //Controls
    public KeyCode up, down, left, right, usePow;

    public float powMax;
    private float pow;

    private Vector2 moveDir;
    public float spd;

    public Rigidbody2D rb;

    public GameObject score;
    private Score_Keep scoreObj;

    public Transform shieldObj;

    private bool dead;
    private bool immune;

    private float respawnCount;
    public float respawnCountMax;
    private Vector2 startPos;

    private Power_Class currentPow;
    private Power_Class shieldPow;
    private Power_Class blastPow;
    private Power_Class boomerangPow;
    private Power_Class teleportPow;

    float powLifetime;

    public Image nrgMet;
    void Start()
    {
        powMax = 5;
        pow = powMax;

        shieldPow = new Power_Class(2, true, 5.0f);
        blastPow = new Power_Class(1);
        boomerangPow = new Power_Class(2);
        teleportPow = new Power_Class(3);
        currentPow = shieldPow;

        shieldObj = transform.GetChild(0);
        shieldObj.gameObject.SetActive(false);
        gcObj = GameObject.FindGameObjectWithTag("GameController");
        gc = gcObj.GetComponent<Projectile_Spawner>();
        respawnCount = respawnCountMax;
        dead = false;
        immune = false;
        scoreObj = score.GetComponent<Score_Keep>();
        startPos = transform.position;
    }
    void Update()
    {
        Debug.Log(currentPow.ToString());
        //if the game is afoot
        if (gc.gameOn)
        {
            //reset velocity to zero every tick
            moveDir = Vector2.zero;
            if (dead)
            {
                transform.position = startPos;
                //start respawn process if dead
                respawnCount -= 1;
                if (respawnCount <= 0)
                {
                    dead = false;
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                //player input
                if (Input.GetKey(up))
                {
                    moveDir.y = 1;
                    //rb.velocity = new Vector2(0, spd);
                }
                if (Input.GetKey(down))
                {
                    moveDir.y = -1;
                    //rb.velocity = new Vector2(0, -spd);
                }
                if (Input.GetKey(left))
                {
                    moveDir.x = -1;
                    //rb.velocity = new Vector2(0, spd);
                }
                if (Input.GetKey(right))
                {
                    moveDir.x = 1;
                    //rb.velocity = new Vector2(0, -spd);
                }

                if (Input.GetKeyDown(usePow) && currentPow != null && pow >= currentPow.energyCost)
                {
                    powLifetime = currentPow.lifeTime;
                    usePower(currentPow);
                }
                if(powLifetime >= 0)
                {
                    powLifetime -= .1f;
                }
                else
                {
                    immune = false;
                    shieldObj.gameObject.SetActive(false);
                }

                moveDir.Normalize();
                rb.velocity = moveDir * spd * Time.deltaTime;
            }
            nrgMet.fillAmount = pow / powMax;
        }
        else
        {
            //when the game ends, set position back to start
            transform.position = startPos;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //new game starts, reset score
                scoreObj.score = 0;
            }
        }
    }

    public void usePower(Power_Class pow)
    {
        this.pow -= currentPow.energyCost;
        if (pow.projectile != null)
        {

        }
        if (pow.shield)
        {
            immune = true;
            shieldObj.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //colliding with obstacle or end will send player back to start
        if (collision.gameObject.tag == ("Finish") || collision.gameObject.tag == ("Projectile") && !immune)
        {
            dead = true;
            respawnCount = respawnCountMax;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.gameObject.tag == ("Finish"))
        {
            scoreObj.score += 1;
            dead = true;
            respawnCount = respawnCountMax;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.gameObject.tag == ("Battery"))
        {
            Destroy(collision.gameObject);
            if(pow < powMax)
            {
                pow += 1;
            }
        }
        if (collision.gameObject.tag == ("ShieldPow"))
        {
            currentPow = shieldPow;
        }
    }
}
