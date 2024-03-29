﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Class
{
    public int energyCost;
    public GameObject projectile;
    public float speedMod;
    public bool shield;
    public float lifeTime;

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
    public Power_Class(int energyCost, int projectileDir, GameObject projectile)
    {
        this.energyCost = energyCost;
        this.speedMod = projectileDir;
        this.projectile = projectile;
        this.lifeTime = lifeTime;
    }
    public Power_Class(int energyCost, float speedMod, float lifeTime)
    {
        this.energyCost = energyCost;
        this.speedMod = speedMod;
        this.lifeTime = lifeTime;
    }
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string ToString()
    {
        if (shield)
        {
            return "Shield Power";
        }
        else
        {
            return "null";
        }
    }
}
