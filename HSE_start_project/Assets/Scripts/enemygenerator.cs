using UnityEngine;
using System.Collections;

public class enemygenerator : MonoBehaviour
{
    public GameObject enemy;
    public float speedreset = 2f;
    public float timer;

    void Start()
    {
        timer = speedreset;
    }

    void Update()
    {
        timer = timer - Time.deltaTime * Memory.Get_Speed();
        if (timer <= 0)
        {
            Instantiate(enemy, new Vector3(Random.Range(-2.5f, 2.5f), 5.5f), transform.rotation);
            timer = speedreset;
        }
    }
}