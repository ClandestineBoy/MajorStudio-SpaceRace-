using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    public float xDir;
    public float yPos;
    public float spd;

    public bool boomerang;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(xDir*spd, 0, 0);
        if (boomerang)
        {
            xDir -= 0.018f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player" && gameObject.tag != "Projectile")
        {
            Destroy(gameObject);
        }
    }


}
