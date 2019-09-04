using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Spawner : MonoBehaviour
{
    public float leftXBound, rightXBound, topYBound, bottomYBound;
    public int spawnCounterMax;
    public int spawnCounter;
    public bool rightSide;
    public float lastY;
    public GameObject projectilePrefab;
    public Vector3 spawnPos;
    void Start()
    {
        lastY = 1;
        rightSide = true;
        spawnCounter = spawnCounterMax;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= 1;
        if(spawnCounter <= 0)
        {
            spawnProjectile();
            spawnCounter = spawnCounterMax;
        }
    }

    public void spawnProjectile()
    {
        float spawnX;
        float spawnY;
        float chance;
        chance = Random.Range(0, 2);
        Debug.Log(chance);
        if (chance >= .5f)
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
        GameObject spawned = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
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
