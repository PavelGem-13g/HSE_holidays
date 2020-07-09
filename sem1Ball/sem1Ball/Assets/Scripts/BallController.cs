using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public float speed = 3.4f;
    public int score;
    public UnityEvent fiveCoinsCollected = new UnityEvent();
    public UnityEvent tenCoinsCollected = new UnityEvent();
    Restart restarter;
    private Rigidbody rb;

    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        restarter = FindObjectOfType<Restart>();
    }

    private void FixedUpdate()
    {
        /*
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontalAxis, 0, verticalAxis) * speed);*/

        Vector3 gravity = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y)*10f;
        rb.AddForce(gravity * speed,ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        CoinController coin = other.GetComponent<CoinController>();
        if(coin != null)
        {
            score += coin.Value;
            coin.Vanish();
            if (score >= 50)
            {
                fiveCoinsCollected.Invoke();
            }
            if (score >= 100)
            {
                tenCoinsCollected.Invoke();
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lava")
        {
            restarter.Load();
        }
        if (collision.gameObject.tag == "Elevator")
        {
            collision.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Elevator")
        {
            collision.gameObject.GetComponent<AudioSource>().Pause();
        }
    }
}
