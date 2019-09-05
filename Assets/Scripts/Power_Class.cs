using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Class
{
    int energyCost;
    GameObject projectile;
    int projectileDir;
    bool shield;
    float lifeTime;

    Power_Class()
    {

    }
    public Power_Class(int energyCost)
    {
        this.energyCost = energyCost;
    }
    public Power_Class(int energyCost, float lifeTime)
    {
        this.energyCost = energyCost;
        this.lifeTime = lifeTime;
    }
    public Power_Class(int energyCost, bool shield, float lifeTime)
    {
        this.energyCost = energyCost;
        this.shield = shield;
        this.lifeTime = lifeTime;
    }
    public Power_Class(int energyCost, int projectileDir, GameObject projectile, float lifeTime)
    {
        this.energyCost = energyCost;
        this.projectileDir = projectileDir;
        this.projectile = projectile;
        this.lifeTime = lifeTime;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
