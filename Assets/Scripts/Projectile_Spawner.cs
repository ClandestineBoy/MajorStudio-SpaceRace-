using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile_Spawner : MonoBehaviour
{
    public bool gameOn;
    public float leftXBound, rightXBound, topYBound, bottomYBound;
    public float spawnCounterMax;
    public float spawnCounter;
    public bool rightSide;
    public float lastY;
    public List<GameObject> projectilePrefabs;
    public Vector3 spawnPos;
    public Image timer;
    public float timerCount, timerCountMax;
    void Start()
    {
        gameOn = false;
        timerCount = timerCountMax;
        lastY = 1;
        rightSide = true;
        spawnCounter = spawnCounterMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOn)
        {
            spawnCounter -= 1 * Time.deltaTime;
            //handle timer
            timerCount -= 1 * Time.deltaTime;
            if (timerCount <= 0)
            {
                gameOn = false;
            }
            timer.fillAmount = timerCount / timerCountMax;
            //time projectile respawn
            if (spawnCounter <= 0)
            {
                spawnProjectile();
                spawnCounter = spawnCounterMax;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOn = true;
                timerCount = timerCountMax;
            }
        }
    }

    public void spawnProjectile()
    {
        float spawnX;
        float spawnY;
        float chance;
        chance = Random.Range(0.0f, 1.0f);
        //Debug.Log(chance);
        if (chance >= 0.5f)
        {
            spawnX = rightXBound;
            rightSide = true;
        }
        else
        {
            spawnX = leftXBound;
            rightSide = false;
        }
        if(lastY >= 0)
        {
            spawnY = Random.Range(bottomYBound, 0);
        }
        else
        {
            spawnY = Random.Range(0, topYBound);
        }
        spawnPos = new Vector2(spawnX, spawnY);

        //random chance to spawn projectiles other than bullets
        float spawnRoll = Random.Range(0.0f,1.0f);
        int numToSpawn;
        if(spawnRoll < 0.04f)
        {
            numToSpawn = 1;
        }
        else if(spawnRoll >= 0.04f && spawnRoll < 0.06f)
        {
            numToSpawn = 2;
        }
        else if (spawnRoll >= 0.06f && spawnRoll < 0.08f)
        {
            numToSpawn = 3;
        }
        else if (spawnRoll >= 0.08f && spawnRoll < 0.1f)
        {
            numToSpawn = 4;
        }
        else if (spawnRoll >= 0.1f && spawnRoll < 0.12f)
        {
            numToSpawn = 5;
        }
        else
        {
            numToSpawn = 0;
        }
        GameObject spawned = Instantiate(projectilePrefabs[numToSpawn], spawnPos, Quaternion.identity);
        if (rightSide)
        {
            spawned.GetComponent<Projectile_Controller>().xDir = -1;
        }
        else
        {
            spawned.GetComponent<Projectile_Controller>().xDir = 1;
        }
       lastY = spawnY;
    }
}
