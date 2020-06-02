﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockgenerator : MonoBehaviour
{
    public GameObject asteroid;
    float timer=0;
    float timerespawn = 0.5f;

    void Start()
    {
        PlayerPrefs.SetInt("tempScore",0);
    }

    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer <=0)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f,0), transform.rotation);
            timer = timerespawn;
        }
    }
}