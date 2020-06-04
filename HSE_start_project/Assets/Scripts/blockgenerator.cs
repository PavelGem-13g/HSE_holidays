using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockgenerator : MonoBehaviour
{
    public GameObject asteroid;
    public float timer =0;
    public float timerespawn = 0.5f;

    void Start()
    {
        PlayerPrefs.SetInt("tempScore",0);
    }

    void Update()
    {
        timer = timer - Time.deltaTime * PlayerPrefs.GetFloat("speedCoeff");
        if (timer <=0)
        {
            Instantiate(asteroid, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f,0), transform.rotation);
            timer = timerespawn;
        }
    }
}
